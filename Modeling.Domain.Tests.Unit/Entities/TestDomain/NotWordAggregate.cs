using Modeling.Domain.Entities;

namespace Modeling.Domain.Tests.Unit.Entities.TestDomain;

internal sealed class NotWordAggregate : AggregateRoot<NotWordAggregateId, Guid>
{
    public NotWordAggregate(NotWordAggregateId id) : base(id)
    {
    }
}