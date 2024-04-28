using FastEndpoints;
using Modeling.Domain.Entities;

namespace Modeling.Endpoints;

public interface IRoutable<TEntity>
    where TEntity : Entity<Guid>;

public abstract class GetResourceEndpoint<TResponse, TEntity> 
    : EndpointWithoutRequest<TResponse>
        , IRoutable<TEntity>
    where TEntity : Entity<Guid>
    where TResponse : notnull
{
    private readonly IRouteFactory _routeFactory;

    protected GetResourceEndpoint(IRouteFactory routeFactory)
    {
        _routeFactory = routeFactory;
    }
    
    public sealed override void Configure()
    {
        Get(_routeFactory.GetRoute(this, "Get"));
        AllowAnonymous();
    }

    /// <inheritdoc />
    public abstract override Task HandleAsync(CancellationToken ct);
}