using Modeling.Infrastructure;

namespace Modeling.Areas.Installation;

public sealed class ModuleInstallerAggregator
{
    public IReadOnlyCollection<IModuleInstaller> ModuleInstallers => _moduleInstallers;
    
    private readonly List<IModuleInstaller> _moduleInstallers = new();

    internal ModuleInstallerAggregator()
    {
    }

    public ModuleInstallerAggregator AddModuleInstaller<TInstaller>()
        where TInstaller : IModuleInstaller, new()
    {
        _moduleInstallers.Add((IModuleInstaller)Activator.CreateInstance(typeof(TInstaller))!);
        
        return this;
    }

}