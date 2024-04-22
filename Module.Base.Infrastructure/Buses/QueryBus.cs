using MediatR;
using Modeling.Application.Cqrs.Queries;
using Truss.Monads.Results;

namespace Module.Base.Infrastructure.Buses;

public sealed class QueryBus : IQueryBus
{
    private readonly IMediator _mediator;

    public QueryBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Result<TResult>> SendQuery<TQuery, TResult>(
        TQuery query,
        CancellationToken cancellationToken
    ) where TQuery : Query<TResult>
    {
        return await _mediator.Send(query, cancellationToken);
    }
}