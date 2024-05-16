using Inventory.Installation;
using Modeling.Areas.Installation;

namespace SupplyChainManagement.Installation;

/// <inheritdoc />
public sealed class SupplyChainManagementAreaInstaller 
    : IAreaInstaller
{
    public void InstallModules(ModuleInstallerAggregator aggregator)
    {
        aggregator
            .AddModuleInstaller<InventoryModuleInstaller>()
            ;
    }
}