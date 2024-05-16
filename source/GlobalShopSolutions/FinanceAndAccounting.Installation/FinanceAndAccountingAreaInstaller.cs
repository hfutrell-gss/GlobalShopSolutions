using AccountsReceivable.Installation;
using Modeling.Areas.Installation;

namespace FinanceAndAccounting.Installation;

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