using GlobalShopSolutions.Sdk.Desktop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceAndAccounting.ClientPackage;

/// <inheritdoc />
public sealed class FinanceAndAccountingDesktopPackageManifest 
    : IDesktopPackageManifest
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
    }
}