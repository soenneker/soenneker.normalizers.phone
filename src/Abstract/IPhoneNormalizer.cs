using Soenneker.Normalizers.Base.Abstract;

namespace Soenneker.Normalizers.Phone.Abstract;

/// <summary>
/// A performant utility method for converting user-entered phone numbers into strict E.164 format, supporting US and international dialing conventions with minimal allocations.
/// </summary>
public interface IPhoneNormalizer : IBaseNormalizer<string?, string?>
{
}
