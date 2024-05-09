using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Tests.Unit.Queries.TestApplication;
using Modeling.Areas.Installation;
using Modeling.Infrastructure;
using Tests.Infrastructure.InMemory;

namespace Modeling.Application.Tests.Unit;

public sealed class ApplicationTestModuleInstaller : 
    IModuleInstaller,
    IAreaInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<ThingStore>()
            ;
    }

    public void InstallModules(ModuleInstallerAggregator aggregator)
    {
        aggregator.AddModuleInstaller<ApplicationTestModuleInstaller>()
                .AddModuleInstaller<InMemoryInfrastructureModuleInstaller>()
            ;
    }
}