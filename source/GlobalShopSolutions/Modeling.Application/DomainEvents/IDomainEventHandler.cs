using MediatR;
using Modeling.Domain.Events;

namespace Modeling.Application.DomainEvents;

/// <summary>
/// For receiving and acting on domain events
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<in TDomainEvent>
    : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;