using AccountsReceivable.Application.Persistence;
using AccountsReceivable.Domain;
using Truss.Monads.Results;

namespace AccountsReceivable.Persistence;

public sealed class AccountRepository : IAccountWriteRepository
{
    private readonly Dictionary<Guid, Account> _accounts = [];
    
    public Task<Result<Guid>> Add(Account account)
    {
        var id = Guid.NewGuid();
        
        _accounts.Add(id, account);
        
        return Task.FromResult(Result.Success(id));
    }
}