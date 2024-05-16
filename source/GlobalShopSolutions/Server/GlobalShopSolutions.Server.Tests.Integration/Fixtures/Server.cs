using Microsoft.Extensions.DependencyInjection;
using Truss.Testing.SharedDependencies;

namespace GlobalShopSolutions.Server.Tests.Integration.Fixtures;

public sealed class Server 
    : ISharedDependency
{
    [SharedDependencyAdapter]
    private ServerAdapter _serverAdapter = null!;
    
    private IServiceProvider _services;

    public async Task StartAsync()
    {
        _services = new ServiceCollection()
                .AddWebServer<Program>()
                .BuildServiceProvider()
            ;
        
       _serverAdapter = new ServerAdapter(_services.GetService<HttpClient>()!);
    }
    
    public async ValueTask DisposeAsync()
    {

    }
}
