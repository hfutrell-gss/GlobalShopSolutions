using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace FinanceAndAccounting.ServerPackage;

/// <inheritdoc />
public sealed class FinanceAndAccountingServerPackageManifest 
    : IServerPackageManifest
{
    /// <inheritdoc />
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
    }
}