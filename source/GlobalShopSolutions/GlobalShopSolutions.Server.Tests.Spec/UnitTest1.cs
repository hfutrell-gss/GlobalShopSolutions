using GlobalShopSolutions.Server.Tests.Spec.Drivers;
using Truss.Testing;

namespace GlobalShopSolutions.Server.Tests.Spec;

[TestFixture]
public sealed class Tests
{
    private readonly FixtureFactory _factory = new();
    private ServerFixture _server;

    [SetUp]
    public void Setup()
    {
        _server = _factory.GetFixture<ServerFixture>();
    }

    [Test]
    public async Task Test1()
    {
        await _server.AssertWelcomeMessage();
    }
}