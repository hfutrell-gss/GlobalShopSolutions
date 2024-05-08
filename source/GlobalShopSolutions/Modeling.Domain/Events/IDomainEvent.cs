using MediatR;

namespace Modeling.Domain.Events;

/// <summary>
/// Marker interface to represent a domain event
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// The unique id of the event
    /// </summary>
    public Guid Id { get; }
}