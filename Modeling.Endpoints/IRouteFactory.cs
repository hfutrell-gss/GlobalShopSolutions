using Modeling.Domain.Entities;

namespace Modeling.Endpoints;

public interface IRouteFactory
{
    public string[] GetRoute<T>(IRoutable<T> routable, string method) 
        where T : Entity<Guid>;
}