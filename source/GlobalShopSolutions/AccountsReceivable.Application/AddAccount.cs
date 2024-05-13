using AccountsReceivable.Domain;
using AccountsReceivable.Integrations;
using FluentValidation;
using GlobalShopSolutions.Server.Sdk.Integrations;
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
    private readonly IIntegrationBus _integrationBus;

    public AddAccountHandler(
        IAccountWriteRepository accountWriteRepository,
        IIntegrationBus integrationBus
    )
    {
        _accountWriteRepository = accountWriteRepository;
        _integrationBus = integrationBus;
    }
    
    public async Task<Result<Guid>> Handle(AddAccount command, CancellationToken cancellationToken)
    {
        var account = Account.New(command.Name);

        var id = await _accountWriteRepository.Add(account);
        
        await _integrationBus.Publish(
                    new CreatedSomethingNeat(),
                    cancellationToken
                );

        return id;
    }
}

public interface IUnitOfWork
{
    public void Commit();
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