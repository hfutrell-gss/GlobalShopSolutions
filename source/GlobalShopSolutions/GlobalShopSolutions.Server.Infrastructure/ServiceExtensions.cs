using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FastEndpoints;
using FinanceAndAccounting.Installation;
using Microsoft.AspNetCore.Builder;
using Modeling.Application.Logging;
using Serilog;
using SupplyChainManagement.Installation;
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
                .InstallArea<SupplyChainManagementAreaInstaller>()
        );
    }

    public static IServiceCollection InstallAreas(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<ServiceInstaller> installation
    )
    {
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(installation);

        var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger()
            ;

       
        logger.Information("Installing Global Shop Solutions infrastructure");
        
        logger.Information("Installing shared module infrastructure");
        new SharedInfrastructureModuleInstaller()
            .InstallServices(services, configuration);
                
        logger.Information("Installing in memory module for development use");
        new InMemoryInfrastructureModuleInstaller()
            .InstallServices(services, configuration);
        
        var installer = new ServiceInstaller(
            services, 
            configuration,
            logger
        );
        
        installation(installer);

        installer.ApplyGlobalResolvers();
        
        services.AddLogging();
        
        return services;
    }

    public static void UseGlobalShopSolutions(this IApplicationBuilder builder)
    {
        var logger = builder.ApplicationServices.GetService<IDiagnosticLogger>()!;
        
        logger.Log("Finalizing installation");
        builder.UseFastEndpoints();
    }
}
