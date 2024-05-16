using AccountsReceivable.Application.Persistence;
using AccountsReceivable.Endpoints;
using AccountsReceivable.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;

namespace AccountsReceivable.Installation;

public sealed class AccountsReceivableModuleInstaller 
    : IModuleInstaller,
        IEndpointInstaller
{
    /// <inheritdoc />
    public void InstallServices(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IAccountWriteRepository, AccountRepository>()
            ;
    }

    public void InstallEndpoints(
        EndpointAggregator endpointAggregator
    )
    {
        endpointAggregator
            .AddEndpointsFrom<AccountsReceivableEndpointAssemblyMarker>();
    }
}