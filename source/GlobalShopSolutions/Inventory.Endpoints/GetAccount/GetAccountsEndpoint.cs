using Inventory.Application;
using Modeling.Endpoints;

namespace Inventory.Endpoints.GetAccount;

public sealed class GetAccountsEndpoint 
    : GetResourceEndpoint<GetAccountsRequest, GetAccountsResponse>
{
    private readonly AccountStore _accountStore;

    public GetAccountsEndpoint(
        IEndpointRouteFactory endpointRouteFactory,
        AccountStore accountStore
    ) 
        : base(endpointRouteFactory)
    {
        _accountStore = accountStore;
    }

    public override async Task HandleAsync(GetAccountsRequest request, CancellationToken ct)
    {

        var accounts = _accountStore.GetAccounts();
        
        await SendAsync(new GetAccountsResponse
            {
                Accounts = accounts.ToList()
            }, 
            200,
            ct);
    }
}