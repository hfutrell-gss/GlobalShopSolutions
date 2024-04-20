using Modeling.Domain.Entities;

namespace Modeling.Domain.Tests.Unit.EventSourcing.TestDomain;

public sealed record TreeId(Guid Value) : AggregateRootId<Guid>(Value);