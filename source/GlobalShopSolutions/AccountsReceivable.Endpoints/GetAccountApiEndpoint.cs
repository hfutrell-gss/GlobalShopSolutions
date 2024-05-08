using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints;

public class GetAccountApiEndpoint 
    : ApiEndpoint<AccountResponse>
{
    public GetAccountApiEndpoint(IRouteFactory routeFactory) : base(routeFactory)
    {
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new AccountResponse("Tim", Guid.NewGuid()), cancellation: ct);
    }
}