using System.Reflection;
using Modeling.Endpoints;

namespace Modeling.Infrastructure;

public sealed class EndpointAggregator
{
    internal readonly List<Assembly> EndpointAssemblies = new();
    
    internal EndpointAggregator()
    {
        
    }
    
    public void AddEndpointsFrom<T>() 
        where T : IEndpointAssemblyMarker, new()
    {
        EndpointAssemblies.Add(typeof(T).Assembly);
    }
}