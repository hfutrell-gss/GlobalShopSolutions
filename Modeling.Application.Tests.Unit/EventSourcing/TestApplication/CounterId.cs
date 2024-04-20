using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.Unit.EventSourcing.TestApplication;

public sealed record CounterId : AggregateRootId<Guid>
{
    public CounterId(Guid value) : base(value)
    {
    }
}