namespace Module.Installer;

public sealed class ModuleInstallerSet
{
    private readonly List<Type> _moduleDefinitions = new();

    public ModuleInstallerSet Add<TDefinition>()
    {
        _moduleDefinitions.Add(typeof(TDefinition));
        
        return this;
    }

    internal Type[] GetModuleTypes()
    {
        return _moduleDefinitions.ToArray();
    }
}