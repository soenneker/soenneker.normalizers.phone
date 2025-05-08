using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Normalizers.Phone.Abstract;

namespace Soenneker.Normalizers.Phone.Registrars;

/// <summary>
/// A performant utility method for converting user-entered phone numbers into strict E.164 format, supporting US and international dialing conventions with minimal allocations.
/// </summary>
public static class PhoneNormalizerRegistrar
{
    /// <summary>
    /// Adds <see cref="IPhoneNormalizer"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPhoneNormalizerAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IPhoneNormalizer, PhoneNormalizer>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPhoneNormalizer"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPhoneNormalizerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IPhoneNormalizer, PhoneNormalizer>();

        return services;
    }
}
