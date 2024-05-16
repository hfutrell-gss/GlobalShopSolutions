namespace AccountsReceivable.Application.GetAccount;

public sealed class AccountInfo
{
    public string Name { get; }
    public Guid Id { get;}
    
    public AccountInfo(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}