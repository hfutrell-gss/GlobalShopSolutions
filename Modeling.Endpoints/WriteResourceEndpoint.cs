using FastEndpoints;
using Modeling.Domain.Entities;
using Truss.Monads.Results;

namespace Modeling.Endpoints;

public abstract class WriteResourceEndpoint<TRequest, TResponse, TEntity> 
    : Endpoint<TRequest, Result<TResponse>>
        , IRoutable<TEntity>
    where TEntity : Entity<Guid>
    where TRequest : notnull
    where TResponse : notnull
{
    private readonly IRouteFactory _routeFactory;

    protected WriteResourceEndpoint(IRouteFactory routeFactory)
    {
        _routeFactory = routeFactory;
    }
    
    public override void Configure()
    {
        Post(_routeFactory.GetRoute(this, "Write"));
    }

    public abstract override Task HandleAsync(TRequest req, CancellationToken ct);
}