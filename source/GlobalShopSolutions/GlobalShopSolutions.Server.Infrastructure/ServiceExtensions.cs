using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AccountsReceivable.Infrastructure;
using FastEndpoints;
using FinanceAndAccounting.ServerPackage;
using Microsoft.AspNetCore.Builder;
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
                set.AddModuleInstaller<AccountingModuleInstaller>();
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
        new ModuleInstaller(
                services,
                configuration
            ).InstallModulesFromSet(modules)
            .InstallModulesFromSet(set => 
                set.AddModuleInstaller<BaseInfrastructureInstaller>()
                    .AddModuleInstaller<InMemoryInfrastructure>()
            )
            .FinalizeGlobalResolvers();

        return services;
    }

    public static IApplicationBuilder UseGlobalShopSolutions(this IApplicationBuilder builder)
    {
        return builder.UseFastEndpoints();
    }
}
