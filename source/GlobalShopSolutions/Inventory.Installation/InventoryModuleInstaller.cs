using Inventory.Application;
using Inventory.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace Inventory.Installation;

public sealed class InventoryModuleInstaller 
    : IModuleInstaller,
        IEndpointInstaller
{
    /// <inheritdoc />
    public void InstallServices(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<AccountStore>();
    }
 
    public void InstallEndpoints(
        EndpointAggregator endpointAggregator
    )
    {
        endpointAggregator.AddEndpointsFrom<InventoryEndpointAssemblyMarker>();
    }
}
