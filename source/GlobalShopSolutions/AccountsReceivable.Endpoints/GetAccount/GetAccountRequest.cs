namespace AccountsReceivable.Endpoints.GetAccount;

public sealed record GetAccountRequest
{
    public Guid Id { get; set; }    
}