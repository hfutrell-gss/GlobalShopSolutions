namespace Modeling.Areas.Installation;

public interface IAreaInstaller
{
    public void InstallModules(ModuleInstallerAggregator aggregator);
}