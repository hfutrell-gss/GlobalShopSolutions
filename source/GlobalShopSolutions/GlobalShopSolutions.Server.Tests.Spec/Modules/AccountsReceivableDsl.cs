using AccountsReceivable.Endpoints.AddAccount;
using GlobalShopSolutions.Server.Tests.Spec.Fixtures;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Spec.Modules;

public class AccountsReceivableDsl(ServerAdapter serverAdapter)
    : Fixture
{
    private const string ModuleEndpoint = "FinanceAndAccounting/AccountsReceivable";
    
    private string Endpoint(string endpoint) => $"{ModuleEndpoint}/{endpoint}";
    
    public async Task CreateAccount()
    {
        await serverAdapter.PostAsync<AddAccountRequest, AddAccountResponse>(
            Endpoint("AddAccountCommand"),
            new AddAccountRequest
            {
                Name = Guid.NewGuid().ToString()
            });
    }
}