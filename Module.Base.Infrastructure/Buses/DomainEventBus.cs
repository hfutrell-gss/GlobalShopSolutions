using MediatR;
using Modeling.Domain.Events;

namespace Module.Base.Infrastructure.Buses;

public sealed class DomainEventBus : IDomainEventBus
{
    private readonly IMediator _mediator;

    public DomainEventBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken) where TDomainEvent : IDomainEvent
    {
        await _mediator.Publish(domainEvent, cancellationToken);
    }
}