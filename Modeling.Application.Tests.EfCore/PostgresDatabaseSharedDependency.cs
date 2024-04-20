using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Truss.Testing.SharedDependencies;

namespace Modeling.Application.Tests.EfCore;

public sealed class PostgresDatabaseSharedDependency 
    : ISharedDependency
{
    public static string? ConnectionString;
    
    [SharedDependencyAdapter]
    // ReSharper disable once NotAccessedField.Global
    public PostgresDependencyAdapter? DependencyAdapter;
    
    private IContainer? _postgresContainer;

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

        ConnectionString = connString;
        
        DependencyAdapter = new PostgresDependencyAdapter(
            connString
        );
    }
    
    public async ValueTask DisposeAsync()
    {
        await _postgresContainer.StopAsync();
        await _postgresContainer.DisposeAsync();
    }

}