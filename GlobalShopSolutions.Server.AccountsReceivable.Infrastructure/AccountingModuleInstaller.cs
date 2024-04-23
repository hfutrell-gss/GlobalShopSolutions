using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace GlobalShopSolutions.Server.AccountsReceivable.Infrastructure;

public class AccountingModuleInstaller : IModuleInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
    }
}