using System.Reflection;
using FastEndpoints;
using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace GlobalShopSolutions.Server.Infrastructure;

internal sealed class ModuleInstallerAgent
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;
    private readonly List<Assembly> _assemblies = new();
    private readonly ChangeEventTypeMap _changeEventTypeMap = new();
    
    private Type[]? _types;
    
    public ModuleInstallerAgent(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        _services = services;
        _configuration = configuration;
    }

    public ModuleInstallerAgent InstallModulesFromSet(
        Action<ModuleInstallerSet> moduleInstallerSetBuilder
    )
    {
        var moduleInstallerSet = new ModuleInstallerSet();

        moduleInstallerSetBuilder(moduleInstallerSet);
        
        _assemblies.AddRange(moduleInstallerSet.GetEndpointAssemblies());

        var assemblies = moduleInstallerSet.GetServiceAssemblies();
        
        _assemblies.AddRange(assemblies);

        _types = assemblies.SelectMany(assembly => assembly.GetTypes())
                .ToArray()
            ;
        
        _changeEventTypeMap.Add(_types);

        InvokeAll<IModuleInstaller>(installer =>
        {
            installer.Install(_services, _configuration);
        });
        return this;
    }

    /// <summary>
    /// Must be invoked after installing modules
    /// </summary>
    public void FinalizeGlobalResolvers()
    {
        var assemblies = _assemblies.ToArray();
        
        _services.AddSingleton(_changeEventTypeMap)
            .AddMediatR(c =>
                c.RegisterServicesFromAssemblies(assemblies))
            .AddFastEndpoints(o =>
                o.Assemblies = assemblies
            )
            ;
         
    }
    
    private void InvokeAll<T>(Action<T> func)
    {
        var types = GetTypes(typeof(T));
        
        foreach (var type in types)
        {
            var instance = (T)Activator.CreateInstance(type)!;
            func(instance);
        }
    }
    
    private IEnumerable<Type> GetTypes(Type typeInterface)
    {
        var closedTypes = _types!
                .Where(t => t.IsClass 
                            && !t.IsAbstract 
                            && t.GetInterfaces().Any(i =>
                                TypeImplements(i, typeInterface)
                            )
                )
            ;
        return closedTypes;
    }
    
    private static bool TypeImplements(Type type, Type typeInterface)
    {
        return type == typeInterface;
    }

}