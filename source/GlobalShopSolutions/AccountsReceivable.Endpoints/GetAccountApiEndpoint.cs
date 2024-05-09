using Modeling.Endpoints;

namespace AccountsReceivable.Endpoints;

public class GetAccountApiEndpoint 
    : ApiEndpoint<AccountResponse>
{
    public GetAccountApiEndpoint(IEndpointRouteFactory endpointRouteFactory) : base(endpointRouteFactory)
    {
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new AccountResponse("Tim", Guid.NewGuid()), cancellation: ct);
    }
}