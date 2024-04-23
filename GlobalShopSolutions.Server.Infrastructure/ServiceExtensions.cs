using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalShopSolutions.Server.AccountsReceivable.Infrastructure;

namespace GlobalShopSolutions.Server.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddGlobalShopSolutionsServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.InstallModules(
            configuration, 
            set => set
                .Add<AccountingModuleInstaller>()
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
            .InstallModulesFromSet(set => set.Add<BaseInfrastructureInstaller>())
            .AddGlobalMappings();

        return services;
    }
}
