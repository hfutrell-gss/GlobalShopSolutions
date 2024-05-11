using AccountsReceivable.Application;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.Queries;
using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints;

public sealed class AddAccountRequest
{
    public required string Name { get; set; }
}

public sealed class AddAccountResponse
{
    public required Guid Id { get; init; }
}

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
        var result = await _commandBus.SendCommand<AddAccount, Guid>(new AddAccount
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
public sealed class GetAccountEndpoint 
    : GetResourceEndpoint<GetAccountRequest, GetAccountResponse>
{
    private readonly IQueryBus _queryBus;

    public GetAccountEndpoint(
        IEndpointRouteFactory endpointRouteFactory,
        IQueryBus queryBus
    ) 
        : base(endpointRouteFactory)
    {
        _queryBus = queryBus;
    }

    public override async Task HandleAsync(GetAccountRequest request, CancellationToken ct)
    {
        var result = await _queryBus.SendQuery<GetAccountRequest, AccountInfo>(request, ct);

        if (result.Succeeded)
        {
            var response = result.SuccessValue;
            
            Response = new GetAccountResponse(response.Name, response.Id);
            
            return;
        }

        await SendNotFoundAsync(ct);
    }
}