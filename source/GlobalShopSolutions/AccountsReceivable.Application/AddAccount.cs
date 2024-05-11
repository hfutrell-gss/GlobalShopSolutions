using AccountsReceivable.Domain;
using FluentValidation;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.Queries;
using Truss.Monads.Results;

namespace AccountsReceivable.Application;

public sealed class AddAccount : ICommand<Guid>
{
    public required string Name { get; init; }
}

public sealed class AddAccountValidator : AbstractValidator<AddAccount>
{
    public AddAccountValidator()
    {
        RuleFor(a => a.Name)
                .Length(3, 24)
            ;
    }
}

public sealed class AddAccountHandler : ICommandHandler<AddAccount, Guid>
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

public sealed record GetAccountRequest : IQuery<AccountInfo>
{
    public Guid Id { get; set; }    
}

public class GetAccountHandler : IQueryHandler<GetAccountRequest, AccountInfo>
{
    public Task<Result<AccountInfo>> Handle(GetAccountRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(new AccountInfo(Guid.NewGuid().ToString(), Guid.NewGuid())));
    }
}

public sealed class AccountInfo
{
    public string Name { get; }
    public Guid Id { get;}
    
    public AccountInfo(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}