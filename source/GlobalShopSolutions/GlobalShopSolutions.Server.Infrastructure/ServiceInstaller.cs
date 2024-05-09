using FastEndpoints;
using GlobalShopSolutions.Server.Infrastructure.EndpointRouting;
using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Areas.Installation;
using Modeling.Endpoints;
using Serilog;

namespace GlobalShopSolutions.Server.Infrastructure;

public sealed class ServiceInstaller
{
    private readonly IServiceCollection _services;
    private readonly ILogger _logger;
    private readonly AreaPackager _areaPackager;
    private readonly List<Area> _areas = [];

    internal ServiceInstaller(
        IServiceCollection services,
        IConfiguration configuration,
        ILogger logger
    )
    {
        _services = services;
        _logger = logger;
        _areaPackager = new AreaPackager(
            services, configuration
        );
    }
    
    public ServiceInstaller InstallArea<TAreaInstaller>() 
        where TAreaInstaller : IAreaInstaller, new()
    {
        var installer = Activator
            .CreateInstance<TAreaInstaller>();

        _logger.Information("Packing area from {Installer}", 
            typeof(TAreaInstaller).Name);
        
        var area = _areaPackager.Package(installer);
        
        _areas.Add(area);

        _logger.Information("Installed area {Area}", area.Name);

        foreach (var module in area.Modules)
        {
            _logger.Information("Installed module {Module} from area {Area}", module.Name, area.Name);
        }
        
        return this;
    }

    /// <summary>
    /// Must be invoked after installing modules
    /// </summary>
    internal void ApplyGlobalResolvers()
    {
        _logger.Information(
            "Applying global resolvers and supporting infrastructure that maps across all modules");
        
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

        var changeEventMapper = new ChangeEventTypeMap(serviceAssemblies, _logger);

        var endpointRouteFactory = new EndpointRouteFactory([.._areas], _logger);
        
        _services.AddSingleton(changeEventMapper)
            .AddSingleton<IEndpointRouteFactory>(endpointRouteFactory)
            ;
        _logger.Information("Adding MediatR");
        _services
            .AddMediatR(c =>
                c.RegisterServicesFromAssemblies([..serviceAssemblies]))
            ;

        if (endpointAssemblies.Count > 0)
        {
            _logger.Information("Adding FastEndpoints");
            _services.AddFastEndpoints(o =>
                    o.Assemblies = endpointAssemblies
                )
                ;
        }
        
        _logger.Information("Global resolvers have been applied");
    }
   
}