using Inventory.Application;

namespace Inventory.Endpoints.GetAccount;

public sealed class GetAccountsResponse
{
    public List<AccountInfo> Accounts { get; set; }
}