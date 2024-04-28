using Modeling.Domain.Entities;
using Modeling.Endpoints;

namespace GlobalShopSolutions.Server.Infrastructure.Routes;

public sealed class RouteFactory : IRouteFactory
{
    public string[] GetRoute<T>(IRoutable<T> routable, string method) where T : Entity<Guid>
    {
        return [$"{typeof(T).Name}/" + "{{{{id}}}}"];
    }
}