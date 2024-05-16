using GlobalShopSolutions.Server.Tests.Spec.Fixtures;
using GlobalShopSolutions.Server.Tests.Spec.Infrastructure.Dsls;

namespace GlobalShopSolutions.Server.Tests.Spec.Infrastructure;

[Collection(nameof(FixtureFactoryCollectionDefinition))]
public sealed class RoodEndpointTests 
{
    private readonly RootEndpointDsl _rootEndpointDsl;

    public RoodEndpointTests(FixtureFactoryLifetimeAdapter adapter)
    {
        _rootEndpointDsl = adapter.FixtureFactory.GetFixture<RootEndpointDsl>();
    }
    
    [Fact]
    public async Task Test1()
    {
        await _rootEndpointDsl.AssertWelcomeMessage();
    }
}