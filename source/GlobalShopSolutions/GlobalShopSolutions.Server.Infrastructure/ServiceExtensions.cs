using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FastEndpoints;
using FinanceAndAccounting.ServerPackage;
using Microsoft.AspNetCore.Builder;
using Tests.Infrastructure.InMemory;

namespace GlobalShopSolutions.Server.Infrastructure;

/// <summary>
///
/// </summary>
public static class ServiceExtensions
{
    public static void AddGlobalShopSolutionsServer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.InstallAreas(
            configuration,
            installation: installer => installer
                .InstallArea<FinanceAndAccountingAreaInstaller>()
        );
    }

    public static IServiceCollection InstallAreas(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<ServiceInstaller> installation
    )
    {
        var installer = new ServiceInstaller(
            services, configuration
        );
        
        new SharedInfrastructureModuleInstaller()
            .InstallServices(services, configuration);
        
        new InMemoryInfrastructureModuleInstaller()
            .InstallServices(services, configuration);
        
        installation(installer);

        installer.FinalizeGlobalResolvers();
        
        return services;
    }

    public static void UseGlobalShopSolutions(this IApplicationBuilder builder)
    {
        builder.UseFastEndpoints();
    }
}
