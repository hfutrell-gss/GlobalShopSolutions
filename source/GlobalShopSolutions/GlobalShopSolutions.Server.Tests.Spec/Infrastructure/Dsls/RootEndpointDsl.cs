using GlobalShopSolutions.Server.Tests.Spec.Fixtures;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Spec.Infrastructure.Dsls;

public sealed class RootEndpointDsl(ServerAdapter serverAdapter)
    : Fixture
{
    public async Task AssertWelcomeMessage()
    {
        var value = await serverAdapter.GetAsync("/");
        
        Assert.Equal("Welcome to the Globe!", value);
    }
}