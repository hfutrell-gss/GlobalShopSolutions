using Modeling.Application.Cqrs.Commands;

namespace AccountsReceivable.Application.AddAccount;

public sealed class AddAccountCommand : ICommand<Guid>
{
    public required string Name { get; init; }
}