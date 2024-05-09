using Modeling.Domain.Entities;

namespace Modeling.Endpoints;

public interface IEndpointRouteFactory
{
    public string[] GetRoute(IRoutable routable, string method);
}