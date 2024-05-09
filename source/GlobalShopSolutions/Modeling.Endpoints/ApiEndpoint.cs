using FastEndpoints;

namespace Modeling.Endpoints;

public interface IRoutable;


public abstract class ApiEndpoint<TResponse> 
    : EndpointWithoutRequest<TResponse>,
        IRoutable where TResponse : notnull
{
    private readonly IEndpointRouteFactory _endpointRouteFactory;

    protected ApiEndpoint(IEndpointRouteFactory endpointRouteFactory)
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