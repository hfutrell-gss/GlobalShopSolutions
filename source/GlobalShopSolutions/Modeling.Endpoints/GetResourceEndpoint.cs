using FastEndpoints;

namespace Modeling.Endpoints;

public abstract class GetResourceEndpoint<TRequest, TResponse> 
    : Endpoint<TRequest, TResponse>,
        IRoutable where TResponse : notnull
{
    private readonly IEndpointRouteFactory _endpointRouteFactory;
    

    protected GetResourceEndpoint(
        IEndpointRouteFactory endpointRouteFactory
    )
    {
        _endpointRouteFactory = endpointRouteFactory;
    }
    
    public sealed override void Configure()
    {
        Post(_endpointRouteFactory.GetRoute(this));
        AllowAnonymous();
    }

    /// <inheritdoc />
    public abstract override Task HandleAsync(TRequest request, CancellationToken ct);

}