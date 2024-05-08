using Modeling.Domain.EventSourcing;

namespace Modeling.Application.Tests.Unit.EventSourcing.TestApplication;

internal sealed record CounterCreatedEvent : CreationEvent<CounterId>
{
    public CounterCreatedEvent(Guid aggregateId) 
        : base(aggregateId)
    {
    }
}