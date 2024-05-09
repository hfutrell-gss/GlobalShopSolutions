using AccountsReceivable.Application;
using AccountsReceivable.Domain;
using AccountsReceivable.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Infrastructure;
using Truss.Monads.Results;

namespace AccountsReceivable.Infrastructure;

public sealed class AccountRepository : IAccountWriteRepository
{
    private readonly Dictionary<Guid, Account> _accounts = [];
    
    public Task<Result<Guid>> Add(Account account)
    {
        var id = Guid.NewGuid();
        
        _accounts.Add(id, account);
        
        return Task.FromResult(Result.Success(id));
    }
}

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