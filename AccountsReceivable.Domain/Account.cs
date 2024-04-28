using Modeling.Domain.Entities;

namespace AccountsReceivable.Domain;

/// <summary>
/// 
/// </summary>
public sealed class Account : Entity<Guid>
{
    public string? Name { get; private set; }
    
    public Account(Guid id) : base(id)
    {
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
