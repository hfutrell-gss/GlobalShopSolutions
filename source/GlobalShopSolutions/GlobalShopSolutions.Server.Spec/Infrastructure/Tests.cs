using GlobalShopSolutions.Server.Spec.Fixtures;
using GlobalShopSolutions.Server.Spec.Infrastructure.Dsls;

namespace GlobalShopSolutions.Server.Spec.Infrastructure;

[Collection(nameof(FixtureFactoryCollectionDefinition))]
public sealed class Tests 
{
    private readonly RootEndpointDsl _rootEndpointDsl;

    public Tests(FixtureFactoryLifetimeAdapter adapter)
    {
        _rootEndpointDsl = adapter.FixtureFactory.GetFixture<RootEndpointDsl>();
    }
    
    [Fact]
    public async Task Test1()
    {
        await _rootEndpointDsl.AssertWelcomeMessage();
    }
}