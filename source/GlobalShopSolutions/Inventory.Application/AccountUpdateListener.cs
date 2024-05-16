using AccountsReceivable.Integrations;
using GlobalShopSolutions.Server.Sdk.Integrations;

namespace Inventory.Application;

public class AccountUpdateListener : IIntegrationEventHandler<AccountCreated>
{
    private readonly AccountStore _accountStore;

    public AccountUpdateListener(AccountStore accountStore)
    {
        _accountStore = accountStore;
    }
    
    public Task Handle(AccountCreated notification, CancellationToken cancellationToken)
    {
        _accountStore.Add(notification.AccountId, notification.Name);
        
        return Task.CompletedTask;
    }
}