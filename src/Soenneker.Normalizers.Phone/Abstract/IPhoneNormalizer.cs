using Soenneker.Normalizers.Base.Abstract;

namespace Soenneker.Normalizers.Phone.Abstract;

/// <summary>
/// Normalizes supported North American and international dialing forms to a plus-prefixed sequence of ASCII digits.
/// </summary>
public interface IPhoneNormalizer : IBaseNormalizer<string?, string?>
{
}
