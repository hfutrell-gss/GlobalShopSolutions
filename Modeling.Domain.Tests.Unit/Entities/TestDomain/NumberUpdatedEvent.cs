using Modeling.Domain.Events;

namespace Modeling.Domain.Tests.Unit.Entities.TestDomain;

public sealed record NumberUpdatedEvent(int Number) : DomainEvent;