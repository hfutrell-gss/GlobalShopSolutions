using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AccountsReceivable.Infrastructure;
using FinanceAndAccounting.ServerPackage;
using Modeling.Infrastructure;
using Tests.Infrastructure.InMemory;

namespace GlobalShopSolutions.Server.Infrastructure;

/// <summary>
///
/// </summary>
public static class ServiceExtensions
{
    public static IServiceCollection AddGlobalShopSolutionsServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        IServicePackage[] servicePackages =
        [
            new FinanceAndAccountingServicePackage()
        ];
        
        services.InstallModules(
            configuration,
            set =>
            {
                servicePackages
                    .Select(package => package.Install(set))
                    .ToList();
                set.AddInstaller<AccountingModuleInstaller>();
            }
        );
        
        return services;
    }
    
    public static IServiceCollection InstallModules(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<ModuleInstallerSet> modules
    )
    {
        new ModuleInstallerAgent(
                services,
                configuration
            ).InstallModulesFromSet(modules)
            .InstallModulesFromSet(set => 
                set.AddInstaller<BaseInfrastructureInstaller>()
                    .AddInstaller<InMemoryInfrastructure>()
            )
            .FinalizeGlobalResolvers();

        return services;
    }
}
