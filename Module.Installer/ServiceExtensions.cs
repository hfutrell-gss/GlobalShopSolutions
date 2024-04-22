using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Base.Infrastructure;

namespace Module.Installer;

public static class ServiceExtensions
{
    public static IServiceCollection InstallModules(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<ModuleInstallerSet> modules
    )
    {
        new InstallerAgent(
                services,
                configuration
            ).InstallModulesFromSet(modules)
            .InstallModulesFromSet(set => set.Add<BaseInfrastructureInstaller>())
            .AddGlobalMappings();

        return services;
    }
}