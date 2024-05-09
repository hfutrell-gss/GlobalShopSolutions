using Modeling.Domain.EventSourcing;

namespace Modeling.Application.Tests.Unit.EventSourcing.TestApplication;

internal sealed record NumberIncrementedEvent : ChangeEvent
{
    public NumberIncrementedEvent(Guid counterId) : base(counterId)
    {
    }
}