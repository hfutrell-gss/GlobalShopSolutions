using FastEndpoints;

namespace Modeling.Endpoints;

public interface IRoutable;


public abstract class ApiEndpoint<TResponse> 
    : EndpointWithoutRequest<TResponse>,
        IRoutable where TResponse : notnull
{
    private readonly IRouteFactory _routeFactory;

    protected ApiEndpoint(IRouteFactory routeFactory)
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