using Modeling.Application.Integrations;

namespace GlobalShopSolutions.Server.AccountsReceivable.Integrations;

/// <summary>
/// 
/// </summary>
public sealed class CreatedSomethingNeat : IIntegrationEvent;

/// <summary>
/// 
/// </summary>
public sealed class GetAccountsOutstanding : IIntegrationRequest<AccountsOutstanding>;

/// <summary>
/// 
/// </summary>
public sealed class AccountsOutstanding : IIntegrationResponse;
