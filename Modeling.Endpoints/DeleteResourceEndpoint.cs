using FastEndpoints;
using Modeling.Domain.Entities;

namespace Modeling.Endpoints;

public abstract class DeleteResourceEndpoint<TRequest, TEntity> 
    : Endpoint<TRequest> 
        , IRoutable<TEntity>
    where TEntity : Entity<Guid>
    where TRequest : notnull
{
    private readonly IRouteFactory _routeFactory;

    protected DeleteResourceEndpoint(IRouteFactory routeFactory)
    {
        _routeFactory = routeFactory;
    }
    public override void Configure()
    {
        Delete(_routeFactory.GetRoute(this, "Delete"));
        SendNoContentAsync();
    }

    public abstract override Task HandleAsync(TRequest req, CancellationToken ct);
}