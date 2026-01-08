using Soenneker.Normalizers.Phone.Abstract;
using Soenneker.Normalizers.Base;
using Soenneker.Extensions.String;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace Soenneker.Normalizers.Phone;

public sealed class PhoneNormalizer : BaseNormalizer<string?, string?>, IPhoneNormalizer
{
    public PhoneNormalizer(ILogger<PhoneNormalizer> logger) : base(logger)
    {
    }

    protected override string? NormalizeCore(string? input)
    {
        if (input.IsNullOrWhiteSpace())
            return null;

        bool hadPlus = input.Length != 0 && input[0] == '+';

        Span<char> digits = stackalloc char[20]; // enough for 011/00 handling + headroom
        var count = 0;

        foreach (char c in input)
        {
            if (IsAsciiDigit(c))
            {
                if ((uint)count >= (uint)digits.Length)
                    return null;

                digits[count++] = c;
            }
        }

        if (count == 10)
            return Create("+1", digits[..10]);

        if (count == 11 && digits[0] == '1')
            return Create("+", digits[..11]);

        if (count > 11)
        {
            // 011XXXXXXXX...
            if (count >= 3 && digits[0] == '0' && digits[1] == '1' && digits[2] == '1')
            {
                int len = count - 3;
                if ((uint)len is >= 11 and <= 15)
                    return Create("+", digits.Slice(3, len));
                return null;
            }

            // 00XXXXXXXX...
            if (count >= 2 && digits[0] == '0' && digits[1] == '0')
            {
                int len = count - 2;
                if ((uint)len is >= 11 and <= 15)
                    return Create("+", digits.Slice(2, len));
                return null;
            }
        }

        if (hadPlus && (uint)count is >= 11 and <= 15)
            return Create("+", digits[..count]);

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsAsciiDigit(char c) => (uint)(c - '0') <= 9;

    private static string Create(string prefix, ReadOnlySpan<char> digits)
    {
        // One allocation: the final string.
        var handler = new DefaultInterpolatedStringHandler(prefix.Length, 1);
        handler.AppendLiteral(prefix);
        handler.AppendFormatted(digits);
        return handler.ToStringAndClear();
    }
}