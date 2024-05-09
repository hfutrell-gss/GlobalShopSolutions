using GlobalShopSolutions.Server.Infrastructure.Buses;
using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using GlobalShopSolutions.Server.Sdk.Integrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.EventSourcing.Reading;
using Modeling.Application.Cqrs.EventSourcing.Writing;
using Modeling.Application.Cqrs.Queries;
using Modeling.Domain.Events;
using Modeling.Infrastructure;

namespace GlobalShopSolutions.Server.Infrastructure;

/// <inheritdoc />
public sealed class SharedInfrastructureModuleInstaller 
    : IModuleInstaller
{
    /// <inheritdoc />
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDomainEventBus, DomainEventBus>()
            .AddTransient<IIntegrationBus, IntegrationBus>()
            .AddTransient<ICommandBus, CommandBus>()
            .AddTransient<IQueryBus, QueryBus>()
            .AddSingleton<ChangeEventSerializer>()
            .AddSingleton<ChangeEventDeserializer>()
            .AddTransient<IAggregateEventStreamWriter, AggregateEventStreamWriter>()
            .AddTransient<IAggregateEventStreamReader, AggregateEventStreamReader>()
            ;
    }
}