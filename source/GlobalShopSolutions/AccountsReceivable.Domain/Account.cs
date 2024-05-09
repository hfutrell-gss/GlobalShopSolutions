using Modeling.Domain.Entities;

namespace AccountsReceivable.Domain;

/// <summary>
/// 
/// </summary>
public sealed class Account : Entity<Guid>
{
    public string? Name { get; private set; }

    private Account() : this(Guid.NewGuid())
    {
        
    }

    private Account(Guid id) : base(id)
    {
    }
    
    public static Account New(string commandName)
    {
        return new Account();
    }

    public static Account From(Guid id)
    {
        return new Account(id);
    }

    public void SetName(string name)
    {
        Name = name;
    }
    
}
