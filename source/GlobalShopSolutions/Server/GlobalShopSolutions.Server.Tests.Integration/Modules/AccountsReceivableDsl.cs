using AccountsReceivable.Endpoints.AddAccount;
using GlobalShopSolutions.Server.Tests.Integration.Fixtures;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Integration.Modules;

public class AccountsReceivableDsl(ServerAdapter serverAdapter)
    : Fixture
{
    private const string ModuleEndpoint = "FinanceAndAccounting/AccountsReceivable";
    
    private string Endpoint(string endpoint) => $"{ModuleEndpoint}/{endpoint}";
    
    public async Task CreateAccount()
    {
        await serverAdapter.PostAsync<AddAccountRequest, AddAccountResponse>(
            Endpoint("AddAccount"),
            new AddAccountRequest
            {
                Name = "jimbo"
            });
    }
}