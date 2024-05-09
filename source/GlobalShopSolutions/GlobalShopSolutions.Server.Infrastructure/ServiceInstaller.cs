using FastEndpoints;
using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using GlobalShopSolutions.Server.Infrastructure.Routes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Areas.Installation;
using Modeling.Endpoints;

namespace GlobalShopSolutions.Server.Infrastructure;

public sealed class ServiceInstaller
{
    private readonly IServiceCollection _services;
    private readonly AreaPackager _areaPackager;
    private readonly List<Area> _areas = [];

    internal ServiceInstaller(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        _services = services;
        _areaPackager = new AreaPackager(
            services, configuration
        );
    }
    
    public ServiceInstaller InstallArea<TAreaInstaller>() 
        where TAreaInstaller : IAreaInstaller, new()
    {
        var installer = Activator
            .CreateInstance<TAreaInstaller>();

        var area = _areaPackager.Package(installer);
        
        _areas.Add(area);

        return this;
    }

    /// <summary>
    /// Must be invoked after installing modules
    /// </summary>
    internal void FinalizeGlobalResolvers()
    {
        var modules = _areas
            .SelectMany(a => a.Modules)
            .ToArray();
        
        var serviceAssemblies = modules
            .SelectMany(m => m.ServiceAssemblies)
            .Distinct()
            .ToList();

        var endpointAssemblies = modules
            .SelectMany(m => m.EndpointAssemblies)
            .Distinct()
            .ToList();
        
        _services.AddSingleton(new ChangeEventTypeMap(serviceAssemblies))
            .AddSingleton<IEndpointRouteFactory>(new EndpointRouteFactory(_areas))
            .AddMediatR(c =>
                c.RegisterServicesFromAssemblies([..serviceAssemblies]))
            ;
        
        if (endpointAssemblies.Count > 0)
            _services.AddFastEndpoints(o =>
                    o.Assemblies = endpointAssemblies
                )
                ;
    }
   
}