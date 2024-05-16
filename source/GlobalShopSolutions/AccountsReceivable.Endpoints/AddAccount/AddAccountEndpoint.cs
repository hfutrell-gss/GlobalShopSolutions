using AccountsReceivable.Application.AddAccount;
using AccountsReceivable.Endpoints.GetAccount;
using Modeling.Application.Cqrs.Commands;
using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints.AddAccount;

public sealed class AddAccountEndpoint 
    : CreateResourceEndpoint<AddAccountRequest, AddAccountResponse>
{
    private readonly ICommandBus _commandBus;

    public AddAccountEndpoint(
        IEndpointRouteFactory endpointRouteFactory,
        ICommandBus commandBus
    ) 
        : base(endpointRouteFactory)
    {
        _commandBus = commandBus;
    }

    public override async Task HandleAsync(AddAccountRequest request, CancellationToken ct)
    {
        var result = await _commandBus.SendCommand<AddAccountCommand, Guid>(new AddAccountCommand
            {
                Name = request.Name
            }, 
            cancellationToken: ct);

        if (result.Succeeded)
        {
            await SendCreatedAtAsync<GetAccountEndpoint>(
                null,
                new AddAccountResponse
                {
                    Id = result.SuccessValue
                },
                cancellation: ct
            );
            
            return;
        }

        AddError(result.FailureMessage);
        
        await SendErrorsAsync(400, cancellation: ct);
    }
}