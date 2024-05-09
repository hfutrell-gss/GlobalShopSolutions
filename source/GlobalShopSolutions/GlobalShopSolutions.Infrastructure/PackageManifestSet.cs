namespace GlobalShopSolutions.Infrastructure;

public sealed class PackageManifestSet
{
    private readonly List<Type> _packageManifests = new();

    public PackageManifestSet Add<TManifest>()
    {
        _packageManifests.Add(typeof(TManifest));
        
        return this;
    }

    internal Type[] GetPackageManifestsTypes()
    {
        return _packageManifests.ToArray();
    }
}