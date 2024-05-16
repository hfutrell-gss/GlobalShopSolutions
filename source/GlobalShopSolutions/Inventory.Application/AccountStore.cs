namespace Inventory.Application;

public sealed class AccountStore
{
    private readonly List<AccountInfo> _accounts = new();
    
    public void Add(Guid id, string name)
    {
        _accounts.Add(new AccountInfo
        {
            Id = id,
            Name = name
        });
    }

    public IReadOnlyCollection<AccountInfo> GetAccounts()
    {
        return _accounts;
    }
}