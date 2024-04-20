using Modeling.Domain.Entities;

namespace Modeling.Domain.Tests.Unit.Entities.TestDomain;

internal sealed record NotWordAggregateId(Guid value) : AggregateRootId<Guid>(value);