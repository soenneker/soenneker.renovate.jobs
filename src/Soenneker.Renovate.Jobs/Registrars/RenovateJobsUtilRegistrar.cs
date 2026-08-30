using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Renovate.Client.Registrars;
using Soenneker.Renovate.Jobs.Abstract;

namespace Soenneker.Renovate.Jobs.Registrars;

/// <summary>
/// Registers Mend Renovate job operations.
/// </summary>
public static class RenovateJobsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IRenovateJobsUtil"/> and its HTTP client wrapper as singleton services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddRenovateJobsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRenovateClientAsSingleton()
                .TryAddSingleton<IRenovateJobsUtil, RenovateJobsUtil>();

        return services;
    }

    /// <summary>
    /// Adds scoped job and client wrappers backed by a singleton HTTP-client cache.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddRenovateJobsUtilAsScoped(this IServiceCollection services)
    {
        services.AddRenovateClientAsScoped()
                .TryAddScoped<IRenovateJobsUtil, RenovateJobsUtil>();

        return services;
    }
}
