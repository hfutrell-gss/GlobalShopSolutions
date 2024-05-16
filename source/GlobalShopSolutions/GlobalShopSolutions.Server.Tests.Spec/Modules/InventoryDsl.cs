using FluentAssertions;
using GlobalShopSolutions.Server.Tests.Spec.Fixtures;
using Inventory.Endpoints.GetAccount;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Spec.Modules;

public class InventoryDsl(ServerAdapter serverAdapter)
    : Fixture
{
    private GetAccountsResponse _accounts;
    private const string ModuleEndpoint = "SupplyChainManagement/Inventory";
    private string Endpoint(string endpoint) => $"{ModuleEndpoint}/{endpoint}";
    
    
    public async Task GetIntegratedAccount()
    {
        _accounts = await serverAdapter.GetAsync<GetAccountsRequest, GetAccountsResponse>(
            Endpoint("GetAccounts"),
            new GetAccountsRequest()
        );
    }
    
    public void AssertAccountExists()
    {
        _accounts.Accounts.Should().NotBeEmpty();
    }
}