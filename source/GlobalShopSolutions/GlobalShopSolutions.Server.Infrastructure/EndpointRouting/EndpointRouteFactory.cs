using Modeling.Areas.Installation;
using Modeling.Endpoints;
using Modeling.Infrastructure;
using Serilog;

namespace GlobalShopSolutions.Server.Infrastructure.EndpointRouting;

public sealed class EndpointRouteFactory 
    : IEndpointRouteFactory
{
    private readonly ILogger _logger;
    private readonly Dictionary<Type, string> _endpoints = [];
    
    public EndpointRouteFactory(Area[] areas, ILogger logger)
    {
        _logger = logger;
        
        RegisterRoutes(areas);
    }
   
    private void RegisterRoutes(Area[] areas)
    {
        foreach (var area in areas)
        {
            RegisterArea(area);
        }
    }

    private void RegisterArea(Area area)
    {
        foreach (var module in area.Modules)
        {
            RegisterModule(area.Name, module);
        }
    }

    private void RegisterModule(string areaName, Module module)
    {
        var endpointTypes = module.EndpointAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(type => typeof(IRoutable).IsAssignableFrom(type))
                .ToArray()
            ;

        foreach (var endpointType in endpointTypes)
        {
            RegisterEndpoint(areaName, module.Name, endpointType);
        }
    }

    private void RegisterEndpoint(string areaName, string moduleName, Type endpointType)
    {
        var endpoint = $"{areaName}/{moduleName}/{endpointType.Name}/{{id}}";
        
        _logger.Information("Routing {EndpointType} to {Endpoint}", endpointType.Name, endpoint);
        
        _endpoints[endpointType] = endpoint;
    }

    public string[] GetRoute(IRoutable routable, string method)
    {
        return [_endpoints[routable.GetType()]];
    }
}