using AccountsReceivable.Domain;
using Truss.Monads.Results;

namespace AccountsReceivable.Application.Persistence;

public interface IAccountWriteRepository
{
    Task<Result<Guid>> Add(Account account);
}