using Modeling.Domain.Entities;
using Modeling.Domain.EventSourcing;
using Truss.Monads.Results;

namespace Modeling.Application.Cqrs.EventSourcing.Writing;

/// <summary>
/// Access a stream to write events
/// </summary>
public interface IAggregateEventStreamWriter
{
    /// <summary>
    /// Append the events to a stream
    /// </summary>
    /// <returns></returns>
    public Task<Result<Nil>> WriteToStream<TId>(
        IEventSourcedAggregateRoot<TId> aggregate,
        CancellationToken cancellationToken = new()
    ) 
        where TId : AggregateRootId<Guid>;
}
