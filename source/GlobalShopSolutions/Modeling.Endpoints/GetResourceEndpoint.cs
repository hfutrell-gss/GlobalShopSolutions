using FastEndpoints;

namespace Modeling.Endpoints;

public interface IRoutable;

public abstract class GetResourceEndpoint<TResponse> 
    : EndpointWithoutRequest<TResponse>,
        IRoutable where TResponse : notnull
{
    private readonly IEndpointRouteFactory _endpointRouteFactory;

    protected GetResourceEndpoint(IEndpointRouteFactory endpointRouteFactory)
    {
        _endpointRouteFactory = endpointRouteFactory;
    }
    
    public sealed override void Configure()
    {
        Get(_endpointRouteFactory.GetRoute(this, "Get"));
        AllowAnonymous();
    }

    /// <inheritdoc />
    public abstract override Task HandleAsync(CancellationToken ct);

}