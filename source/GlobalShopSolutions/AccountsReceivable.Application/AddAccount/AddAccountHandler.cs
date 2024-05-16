using AccountsReceivable.Application.Persistence;
using AccountsReceivable.Domain;
using AccountsReceivable.Integrations;
using GlobalShopSolutions.Server.Sdk.Integrations;
using Modeling.Application.Cqrs.Commands;
using Truss.Monads.Results;

namespace AccountsReceivable.Application.AddAccount;

public sealed class AddAccountHandler : ICommandHandler<AddAccountCommand, Guid>
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
    
    public async Task<Result<Guid>> Handle(AddAccountCommand command, CancellationToken cancellationToken)
    {
        var account = Account.New(command.Name);

        return await _accountWriteRepository.Add(account)
            .Do(id => _integrationBus.Publish(
                    new AccountCreated
                    {
                        AccountId = id,
                        Name = command.Name
                    },
                    cancellationToken
                )
            );
    }
}