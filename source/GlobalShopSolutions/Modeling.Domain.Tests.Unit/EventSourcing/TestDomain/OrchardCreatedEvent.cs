using Modeling.Domain.EventSourcing;

namespace Modeling.Domain.Tests.Unit.EventSourcing.TestDomain;

public sealed record OrchardCreatedEvent(OrchardId? aggregateId, string? Name) : CreationEvent<OrchardId>(aggregateId);