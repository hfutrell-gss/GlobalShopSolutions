using Modeling.Domain.Entities;

namespace Modeling.Domain.Tests.Unit.Entities.TestDomain;

internal sealed record WordAggregateId(Guid value) : AggregateRootId<Guid>(value)
{
    public static WordAggregateId New()
    {
        return new WordAggregateId(Guid.NewGuid());
    }
};