using Modeling.Areas.Installation;
using Modeling.Endpoints;

namespace GlobalShopSolutions.Server.Infrastructure.Routes;

public sealed class EndpointRouteFactory 
    : IEndpointRouteFactory
{
    public EndpointRouteFactory(
        List<Area> areas
    )
    {
    }

    public string[] GetRoute(IRoutable routable, string method)
    {
        return [$"{""}/{{id}}"];
    }
}