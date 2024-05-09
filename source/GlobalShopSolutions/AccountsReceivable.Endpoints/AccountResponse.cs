namespace AccountsReceivable.Endpoints;

public sealed class AccountResponse
{
    public Guid Id { get; }
    public string Name { get; }

    public AccountResponse(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}