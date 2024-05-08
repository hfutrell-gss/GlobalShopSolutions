using Modeling.Domain.Events;

namespace Modeling.Domain.Entities;

/// <summary>
/// An aggregate root per DDD
/// </summary>
public interface IAggregateRoot
{
    /// <summary>
    /// The domain events stored on the aggregate
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents();
    
    /// <summary>
    /// Clear the aggregate's domain events
    /// </summary>
    public void ClearEvents();
}