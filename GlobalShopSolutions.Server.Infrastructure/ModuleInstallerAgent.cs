using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace GlobalShopSolutions.Server.Infrastructure;

internal sealed class ModuleInstallerAgent
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;
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

        var assemblies = moduleInstallerSet.GetModuleTypes()
            .Select(moduleType => moduleType.Assembly)
            .ToArray();

        _services.AddMediatR(c =>
            c.RegisterServicesFromAssemblies(assemblies));
        
        _types = moduleInstallerSet.GetModuleTypes()
                .SelectMany(moduleType => moduleType
                        .Assembly
                        .GetTypes())
                .ToArray()
            ;
        
        _changeEventTypeMap.Add(_types);

        InvokeAll<IModuleInstaller>(installer => installer.Install(_services, _configuration));
        return this;
    }

    /// <summary>
    /// Must be invoked after installing modules
    /// </summary>
    public void AddGlobalMappings()
    {
        _services.AddSingleton(_changeEventTypeMap);
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