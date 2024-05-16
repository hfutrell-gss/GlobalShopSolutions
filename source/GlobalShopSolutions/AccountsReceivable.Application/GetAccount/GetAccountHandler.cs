using Modeling.Application.Cqrs.Queries;
using Truss.Monads.Results;

namespace AccountsReceivable.Application.GetAccount;

public class GetAccountHandler : IQueryHandler<GetAccountQuery, AccountInfo>
{
    public Task<Result<AccountInfo>> Handle(GetAccountQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(new AccountInfo(Guid.NewGuid().ToString(), Guid.NewGuid())));
    }
}