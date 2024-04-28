using System.Reflection;
using Modeling.Endpoints;

namespace Modeling.Infrastructure;

public sealed class ModuleInstallerSet
{
    private readonly List<Assembly> _serviceAssemblies = new();
    private readonly List<Assembly> _endpointAssemblies = new();

    public ModuleInstallerSet AddInstaller<TInstaller>()
        where TInstaller : IModuleInstaller
    {
        _serviceAssemblies.Add(typeof(TInstaller).Assembly);
        
        return this;
    }

    public ModuleInstallerSet AddEndpointsFromAssembly<TEndpointManifest>()
        where TEndpointManifest : IEndpointManifest
    {
        _endpointAssemblies.Add(typeof(TEndpointManifest).Assembly);

        return this;
    }

    public Assembly[] GetServiceAssemblies()
    {
        return _serviceAssemblies.ToArray();
    }

    public Assembly[] GetEndpointAssemblies()
    {
        return _endpointAssemblies.ToArray();
    }
}