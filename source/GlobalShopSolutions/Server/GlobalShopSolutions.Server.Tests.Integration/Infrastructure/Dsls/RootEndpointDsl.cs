using GlobalShopSolutions.Server.Tests.Integration.Fixtures;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Integration.Infrastructure.Dsls;

public sealed class RootEndpointDsl(ServerAdapter serverAdapter)
    : Fixture
{
    public async Task AssertWelcomeMessageIsWelcomeToTheGlobe()
    {
        var value = await serverAdapter.GetAsync("/");
        
        Assert.Equal("Welcome to the Globe!", value);
    }
}