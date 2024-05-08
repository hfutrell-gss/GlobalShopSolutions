using GlobalShopSolutions.Server.Sdk.Integrations;

namespace AccountsReceivable.Integrations;

public sealed class CreatedSomethingNeat : IIntegrationEvent;

// ReSharper disable once UnusedType.Global
/// <inheritdoc />
public sealed class GetAccountsOutstanding : IIntegrationRequest<AccountsOutstanding>;

/// <inheritdoc />
public sealed class AccountsOutstanding : IIntegrationResponse;
