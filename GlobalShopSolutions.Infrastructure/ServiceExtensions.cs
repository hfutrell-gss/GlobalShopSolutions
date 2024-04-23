using FinanceAndAccounting.ClientPackage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalShopSolutions.Infrastructure;

/// <summary>
/// Provides extension methods for configuring services in the GlobalShopSolutions infrastructure.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds the GlobalShopSolutionsDesktop packages to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The service collection with the GlobalShopSolutionsDesktop package added.</returns>
    public static IServiceCollection AddGlobalShopSolutionsDesktop(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var installer = new PackageInstallerAgent(services, configuration)
            .InstallPackagesFromSet(set => set.Add<FinanceAndAccountingDesktopPackageManifest>());
        return services;
    }
}