using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.EventSourcing.Writing;
using Modeling.Infrastructure;
using Tests.Infrastructure.InMemory.Events;

namespace Tests.Infrastructure.InMemory;

public sealed class InMemoryInfrastructure 
    : IModuleInstaller
{
    public void Install(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton<IEventStore, InMemoryEventStore>();
    }
}