```
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Renovate.Client.Registrars;
using Soenneker.Renovate.Jobs.Abstract;

namespace Soenneker.Renovate.Jobs.Registrars;

/// <summary>
/// A utility library for Mend Renovate job related operations
/// </summary>
public static class RenovateJobsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IRenovateJobsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRenovateJobsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddRenovateClientAsSingleton();
        services.TryAddSingleton<IRenovateJobsUtil, RenovateJobsUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IRenovateJobsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRenovateJobsUtilAsScoped(this IServiceCollection services)
    {
        services.AddRenovateClientAsScoped();
        services.TryAddScoped<IRenovateJobsUtil, RenovateJobsUtil>();
        return services;
    }
}
```