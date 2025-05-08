using Soenneker.Normalizers.Phone.Abstract;
using System;
using Soenneker.Normalizers.Base;
using Soenneker.Extensions.String;
using Soenneker.Extensions.Char;
using Microsoft.Extensions.Logging;

namespace Soenneker.Normalizers.Phone;

/// <inheritdoc cref="IPhoneNormalizer"/>
public class PhoneNormalizer : BaseNormalizer<string?, string?>, IPhoneNormalizer
{
    public PhoneNormalizer(ILogger<PhoneNormalizer> logger) : base(logger)
    {
    }

    protected override string? NormalizeCore(string? input)
    {
        if (input.IsNullOrWhiteSpace())
            return null;

        // Pre-allocate buffer on stack for max expected length
        Span<char> buffer = stackalloc char[20]; // >15 digits never valid E.164
        var i = 0;

        foreach (char c in input)
        {
            if (c.IsDigit())
            {
                if (i >= buffer.Length)
                    return null; // too long to be valid
                buffer[i++] = c;
            }
        }

        if (i == 10)
        {
            // US without country code
            return $"+1{new string(buffer[..i])}";
        }

        if (i == 11 && buffer[0] == '1')
        {
            // US with leading 1
            return $"+{new string(buffer[..i])}";
        }

        // Check for international prefixes
        if (i > 11)
        {
            if (buffer.StartsWith("011"))
                return $"+{new string(buffer[3..i])}";

            if (buffer.StartsWith("00"))
                return $"+{new string(buffer[2..i])}";
        }

        // Handle + already in original input (must recheck input not buffer)
        if (input.StartsWith('+') && i is >= 11 and <= 15)
        {
            return $"+{new string(buffer[..i])}";
        }

        return null;
    }
}