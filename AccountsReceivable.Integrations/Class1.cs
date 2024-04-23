using GlobalShopSolutions.Server.Sdk.Integrations;

namespace AccountsReceivable.Integrations;

public sealed class CreatedSomethingNeat : IIntegrationEvent;

public sealed class GetAccountsOutstanding : IIntegrationRequest<AccountsOutstanding>;

public sealed class AccountsOutstanding : IIntegrationResponse;
