using AccountsReceivable.Domain;
using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints;

public class GetAccountEndpoint 
    : GetResourceEndpoint<AccountResponse,Account>
{
    public GetAccountEndpoint(IRouteFactory routeFactory) : base(routeFactory)
    {
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new AccountResponse("Tim", Guid.NewGuid()), cancellation: ct);
    }
}