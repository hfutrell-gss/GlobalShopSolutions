using AccountsReceivable.Infrastructure;
using Modeling.Areas.Installation;

namespace FinanceAndAccounting.ServerPackage;

/// <inheritdoc />
public sealed class FinanceAndAccountingAreaInstaller 
    : IAreaInstaller
{
    public void InstallModules(ModuleInstallerAggregator aggregator)
    {
        aggregator
            .AddModuleInstaller<AccountsReceivableModuleInstaller>()
            ;
    }
}