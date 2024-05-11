using Microsoft.Extensions.DependencyInjection;
using Truss.Testing;
using Truss.Testing.Services;

namespace GlobalShopSolutions.Server.Tests.Spec.Drivers;

public sealed class ServerFixture(ServerFixtureClient client)
    : Fixture
{
    [BaseServices] 
    public static IServiceCollection Services = new ServiceCollection()
            .AddSingleton<ServerFixtureClient>()
            .AddWebServer<Program>()
        ;

    public async Task AssertWelcomeMessage()
    {
        
        var value = await client.Get("/");
        
        Assert.That(value, Is.EqualTo("Welcome to the Globe!"));
    }
}