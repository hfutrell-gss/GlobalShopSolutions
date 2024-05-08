using Modeling.Endpoints;

namespace GlobalShopSolutions.Server.Infrastructure.Routes;

public sealed class RouteFactory : IRouteFactory
{
    public string[] GetRoute(IRoutable routable, string method)
    {
        return [$"{""}/{{id}}"];
    }
}