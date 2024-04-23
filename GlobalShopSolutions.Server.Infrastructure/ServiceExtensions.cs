using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalShopSolutions.FinanceAndAccounting.Infrastructure;
using Module.Installer;

namespace GlobalShopSolutions.Server.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddGlobalShopSolutions(
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
}
