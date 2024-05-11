using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Truss.Testing.SharedDependencies;

namespace GlobalShopSolutions.Server.Spec.Fixtures;

public sealed class Server 
    : ISharedDependency
{
    private IContainer? _postgresContainer;

    [SharedDependencyAdapter]
    private PostgresDependencyAdapter? _postgresDependencyAdapter;

    [SharedDependencyAdapter]
    private ServerAdapter _serverAdapter = null!;
    
    private IContainer? _serverContainer;

    public async Task StartAsync()
    {
        var username = $"test_user_{Guid.NewGuid()}";
        var password = Guid.NewGuid().ToString();
        
        _postgresContainer = new ContainerBuilder()
                .WithImage("postgres:latest")
                .WithEnvironment(new Dictionary<string, string>
                {
                    { "POSTGRES_USER", username },
                    { "POSTGRES_PASSWORD", password }
                })
                .WithPortBinding(5432, true)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(5432))
                .Build()
            ;
        
        await _postgresContainer.StartAsync();
                
        var postgresPort = _postgresContainer.GetMappedPublicPort(5432);
        
        var connString =
            $"Server=localhost;Port={postgresPort};Database=Autos;Username={username};Password={password}";
        
        _postgresDependencyAdapter = new PostgresDependencyAdapter(
            connString
        );

        _serverContainer = new ContainerBuilder()
                .WithImage("globalshopsolutions.server:dev")
                .WithName("globalshopsolutions.server.dev")
                .WithPortBinding(8080, true)
                .WithWaitStrategy(Wait
                    .ForUnixContainer()
                    .UntilPortIsAvailable(8080)
                )
                .Build()
            ;

        await _serverContainer.StartAsync();

        var port = _serverContainer.GetMappedPublicPort(8080);
        
        _serverAdapter = new ServerAdapter(
            new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:{port}")
            }
        );
    }
    
    public async ValueTask DisposeAsync()
    {
        await _postgresContainer!.DisposeAsync();
        await _serverContainer!.DisposeAsync();
    }

}

public sealed class PostgresDependencyAdapter
{
    public string ConnectionString { get; }
    public PostgresDependencyAdapter(string connectionString)
    {
        ConnectionString = connectionString;
    }
}