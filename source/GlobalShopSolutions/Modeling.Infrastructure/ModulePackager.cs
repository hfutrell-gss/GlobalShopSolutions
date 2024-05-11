using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modeling.Infrastructure;


public sealed class ModulePackager
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;

    public ModulePackager(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        _configuration = configuration;
        _services = services;
    }
    
    public Module Package(IModuleInstaller moduleInstaller)
    {
        var serviceAssemblies = 
            InstallServicesWhileReadingOutUtilizedAssemblies(moduleInstaller);

        var type = moduleInstaller.GetType();
        
        var (moduleName, description) = GetMetadata(type);
        
        var endpointAssemblies =
            InstallEndpointsWhileReadingOutUtilizedAssemblies(type);
        
        return new Module
        {
            Name = moduleName,
            Description = description,
            Services = _services,
            ServiceAssemblies = serviceAssemblies,
            EndpointAssemblies = endpointAssemblies
        };
    }

    private List<Assembly> InstallServicesWhileReadingOutUtilizedAssemblies(IModuleInstaller moduleInstaller)
    {
        var serviceAssemblies = new List<Assembly>();
        var services = new ServiceCollection();
        
        moduleInstaller.InstallServices(services, _configuration);

        serviceAssemblies.AddRange(services.SelectMany(s => 
            new[]
            {
                s.ServiceType.Assembly,
                s.ImplementationType?.Assembly,
            })!);
        
        foreach (var serviceDescriptor in services)
        {
            _services.Add(serviceDescriptor);
        }

        return serviceAssemblies;
    }

    private List<Assembly> InstallEndpointsWhileReadingOutUtilizedAssemblies(Type moduleInstallerType)
    {
        var endpointAggregator = new EndpointAggregator();
        
        var endpointInstaller = GetClosedTypeFromModule<IEndpointInstaller>(moduleInstallerType);

        endpointInstaller?.InstallEndpoints(endpointAggregator);

        var endpointAssemblies = new List<Assembly>();
        endpointAssemblies.AddRange(endpointAggregator.EndpointAssemblies);
        
        return endpointAssemblies;
    }
    
    private (string Name, string Description) GetMetadata(Type moduleInstallerType)
    {
        var metadata = GetClosedTypeFromModule<IModuleMetadata>(moduleInstallerType);
        
        if (metadata is not null)
        {
            return (metadata.Name, metadata.Description);
        }
            
        var moduleName = moduleInstallerType.Name
            .Replace("ModuleInstaller", "");

        var description = $"The {moduleName} module";

        return (moduleName, description);
    }

    private TInterface? GetClosedTypeFromModule<TInterface>(Type type)
    {
        var types = type.Assembly.GetTypes();
        
        var closedType = types
                .FirstOrDefault(
                    t => t is { IsClass: true, IsAbstract: false }
                         && t.GetInterfaces().Any(i =>
                             i == typeof(TInterface))
                )
            ;

        if (closedType is not null) return (TInterface)Activator.CreateInstance(closedType)!;
        
        return default;
    }
}