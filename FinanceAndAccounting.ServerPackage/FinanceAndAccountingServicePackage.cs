using AccountsReceivable.Endpoints;
using AccountsReceivable.Infrastructure;
using Modeling.Infrastructure;

namespace FinanceAndAccounting.ServerPackage;

/// <inheritdoc />
public sealed class FinanceAndAccountingServicePackage 
    : IServicePackage
{
    public ModuleInstallerSet Install(ModuleInstallerSet installer)
    {
        return installer
            .AddInstaller<AccountingModuleInstaller>()
            .AddEndpointsFromAssembly<AccountsReceivableEndpointManifest>()
            ;
    }
}