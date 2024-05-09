using AccountsReceivable.Domain;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.Queries;
using Truss.Monads.Results;

namespace AccountsReceivable.Application;

public class AddAccount : ICommand<Guid>
{
    public string Name { get; set; }
}

public class AddAccountHandler : ICommandHandler<AddAccount, Guid>
{
    private readonly IAccountWriteRepository _accountWriteRepository;

    public AddAccountHandler(IAccountWriteRepository accountWriteRepository)
    {
        _accountWriteRepository = accountWriteRepository;
    }
    
    public async Task<Result<Guid>> Handle(AddAccount command, CancellationToken cancellationToken)
    {
        var account = Account.New(command.Name);
        
        return await _accountWriteRepository.Add(account);
    }
}

public interface IAccountWriteRepository
{
    Task<Result<Guid>> Add(Account account);
}

public record GetAccount : IQuery<AccountInfo>
{
    public Guid Id { get; set; }    
}

public class GetAccountHandler : IQueryHandler<GetAccount, AccountInfo>
{
    public Task<Result<AccountInfo>> Handle(GetAccount request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(new AccountInfo()));
    }
}

public class AccountInfo
{
    public string Name { get; }
}