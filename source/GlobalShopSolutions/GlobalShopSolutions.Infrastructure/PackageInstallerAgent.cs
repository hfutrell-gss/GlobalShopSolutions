using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalShopSolutions.Infrastructure;

/// <summary>
/// Registers the package manager and populates
/// it with base packages from the base manifests
/// </summary>
internal sealed class PackageInstallerAgent
{
    private readonly IServiceCollection _services;
    private readonly IConfiguration _configuration;
    
    private Type[]? _types;
    
    public PackageInstallerAgent(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        _services = services;
        _configuration = configuration;
    }

    public PackageInstallerAgent InstallPackagesFromSet(
        Action<PackageManifestSet> packageManifestSetBuilder
    )
    {
        var packageManager = new PackageManager(_services);
        
        var packageManifestSet = new PackageManifestSet();

        packageManifestSetBuilder(packageManifestSet);
        
        _types = packageManifestSet.GetPackageManifestsTypes()
                .SelectMany(packageManifestType => packageManifestType
                        .Assembly
                        .GetTypes())
                .ToArray()
            ;
        
        return this;
    }

    private void AddAll<T>(Action<T> func)
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
