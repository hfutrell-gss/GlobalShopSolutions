using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Spec.Fixtures;

public sealed class FixtureFactoryLifetimeAdapter : IAsyncLifetime
{
    public FixtureFactory FixtureFactory { get; } = new();
    
    public async Task InitializeAsync()
    {
        await FixtureFactory.InitializeAsync(
            [typeof(Server).Assembly]
        );
    }

    public async Task DisposeAsync()
    {
        await FixtureFactory.DisposeAsync();
    }
}