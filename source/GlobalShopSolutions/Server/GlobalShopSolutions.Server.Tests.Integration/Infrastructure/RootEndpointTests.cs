using GlobalShopSolutions.Server.Tests.Integration.Fixtures;
using GlobalShopSolutions.Server.Tests.Integration.Infrastructure.Dsls;

namespace GlobalShopSolutions.Server.Tests.Integration.Infrastructure;

[Collection(nameof(FixtureFactoryCollectionDefinition))]
public sealed class RootEndpointTests 
{
    private readonly RootEndpointDsl _rootEndpointDsl;

    public RootEndpointTests(FixtureFactoryLifetimeAdapter adapter)
    {
        _rootEndpointDsl = adapter.FixtureFactory.GetFixture<RootEndpointDsl>();
    }
    
    [Fact]
    public async Task WelcomeMessageIsCorrect()
    {
        await _rootEndpointDsl.AssertWelcomeMessageIsWelcomeToTheGlobe();
    }
}