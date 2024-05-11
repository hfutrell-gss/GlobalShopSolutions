namespace AccountsReceivable.Endpoints;

public sealed class GetAccountResponse
{
    public Guid Id { get; }
    public string Name { get; }

    public GetAccountResponse(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}