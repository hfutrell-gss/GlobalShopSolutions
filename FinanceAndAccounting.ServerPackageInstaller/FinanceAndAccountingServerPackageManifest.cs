using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace FinanceAndAccounting.ServerPackageInstaller;

/// <inheritdoc />
public class FinanceAndAccountingServerPackageManifest 
    : IServerPackageManifest
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
    }
}