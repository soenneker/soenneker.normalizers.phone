using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Normalizers.Phone.Abstract;

namespace Soenneker.Normalizers.Phone.Registrars;

/// <summary>
/// Registers the phone-number normalizer.
/// </summary>
public static class PhoneNormalizerRegistrar
{
    /// <summary>
    /// Adds <see cref="IPhoneNormalizer"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPhoneNormalizerAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IPhoneNormalizer, PhoneNormalizer>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPhoneNormalizer"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPhoneNormalizerAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IPhoneNormalizer, PhoneNormalizer>();

        return services;
    }
}
