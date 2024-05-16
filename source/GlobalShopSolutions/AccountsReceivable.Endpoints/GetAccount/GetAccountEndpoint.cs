using AccountsReceivable.Application.GetAccount;
using Modeling.Application.Cqrs.Queries;
using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints.GetAccount;

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
        var query = new GetAccountQuery
        {
            Id = request.Id
        };
        
        var result = await _queryBus.SendQuery<GetAccountQuery, AccountInfo>(query, ct);

        if (result.Succeeded)
        {
            var response = result.SuccessValue;
            
            Response = new GetAccountResponse(response.Name, response.Id);
            
            return;
        }

        await SendNotFoundAsync(ct);
    }
}