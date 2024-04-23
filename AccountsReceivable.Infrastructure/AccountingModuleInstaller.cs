using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace AccountsReceivable.Infrastructure;

/// <inheritdoc />
public sealed class AccountingModuleInstaller : IModuleInstaller
{
    /// <inheritdoc />
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
    }
}