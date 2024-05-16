using Modeling.Application.Cqrs.Queries;

namespace AccountsReceivable.Application.GetAccount;

public sealed record GetAccountQuery : IQuery<AccountInfo>
{
    public required Guid Id { get; init; }    
}