using Modeling.Domain.Entities;

namespace Modeling.Endpoints;

public interface IRouteFactory
{
    public string[] GetRoute(IRoutable routable, string method);
}