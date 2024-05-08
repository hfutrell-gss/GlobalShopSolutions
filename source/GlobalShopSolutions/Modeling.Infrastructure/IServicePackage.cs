namespace Modeling.Infrastructure;

public interface IServicePackage
{
    public ModuleInstallerSet Install(ModuleInstallerSet installer);
}