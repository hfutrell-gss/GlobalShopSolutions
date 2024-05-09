using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints;

public class GetAccountGetResourceEndpoint 
    : GetResourceEndpoint<AccountResponse>
{
    public GetAccountGetResourceEndpoint(IEndpointRouteFactory endpointRouteFactory) : base(endpointRouteFactory)
    {
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new AccountResponse("Tim", Guid.NewGuid()), cancellation: ct);
    }
}