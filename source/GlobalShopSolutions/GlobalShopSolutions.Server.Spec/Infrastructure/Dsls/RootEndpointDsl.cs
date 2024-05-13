using GlobalShopSolutions.Server.Spec.Fixtures;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Spec.Infrastructure.Dsls;

public sealed class RootEndpointDsl(ServerAdapter serverAdapter)
    : Fixture
{
    public async Task AssertWelcomeMessage()
    {
        var value = await serverAdapter.Get("/");
        
        Assert.Equal("Welcome to the Globe!", value);
    }
}