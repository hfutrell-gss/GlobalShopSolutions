using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace Modeling.Areas.Installation;

public sealed class AreaPackager
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;
    private readonly ModulePackager _modulePackager;

    public AreaPackager(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        _services = services;
        _configuration = configuration;
        _modulePackager = new ModulePackager(services, configuration);
    }
    
    public Area Package(IAreaInstaller areaInstaller)
    {
        var name = areaInstaller.GetType().Name.Replace("AreaInstaller", "");

        var moduleInstallerAggregator = new ModuleInstallerAggregator();
        
        areaInstaller.InstallModules(moduleInstallerAggregator);
        
        var modules = moduleInstallerAggregator.ModuleInstallers.Select(installer =>
                    _modulePackager.Package(installer))
                .ToArray()
            ;

        return new Area
        {
            Name = name,
            Modules = modules
        };
    }
}