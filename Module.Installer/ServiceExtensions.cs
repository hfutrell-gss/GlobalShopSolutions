using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            .InstallModulesFromSet(set => set.Add<InfrastructureModuleInstaller>())
            .AddGlobalMappings();

        return services;
    }
}