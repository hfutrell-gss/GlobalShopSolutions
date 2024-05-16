namespace Inventory.Application;

public sealed class AccountInfo
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}