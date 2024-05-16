using GlobalShopSolutions.Server.Sdk.Integrations;

namespace AccountsReceivable.Integrations;

public sealed class AccountCreated : IIntegrationEvent
{
    public required Guid AccountId { get; init; }
    public required string Name { get; init; }
}