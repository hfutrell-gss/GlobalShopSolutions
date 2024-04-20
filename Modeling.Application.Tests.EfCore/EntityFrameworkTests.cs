using Truss.Testing;

namespace Modeling.Application.Tests.EfCore;

public sealed class EntityFrameworkTests 
    : IClassFixture<FixtureFactoryLifetimeAdapter>
{
    private readonly FixtureFactory _factory;

    public EntityFrameworkTests(FixtureFactoryLifetimeAdapter factory)
    {
        _factory = factory.FixtureFactory;
    }
    
    [Fact]
    public async Task CanUseDslAndDriver()
    {
        var dsl = _factory.GetFixture<AutoShopFixture>();

        await dsl.AddAndGetShopUsingDslAndDriver("name: phillips");
    }
    
    [Fact]
    public void CanUseDependenciesDirectlyOnTheDsl()
    {
        var dsl = _factory.GetFixture<AutoShopFixture>();
    
        dsl.AddAndGetShopOnDsl();
    }
}