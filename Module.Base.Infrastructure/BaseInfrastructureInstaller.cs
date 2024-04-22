using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.EventSourcing.Reading;
using Modeling.Application.Cqrs.EventSourcing.Writing;
using Modeling.Application.Cqrs.Queries;
using Modeling.Domain.Events;
using Modeling.Infrastructure;
using Module.Base.Infrastructure.Buses;
using Module.Base.Infrastructure.EventSourcing; 

namespace Module.Base.Infrastructure;

public class BaseInfrastructureInstaller : IModuleInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDomainEventBus, DomainEventBus>()
            .AddTransient<ICommandBus, CommandBus>()
            .AddTransient<IQueryBus, QueryBus>()
            .AddSingleton<ChangeEventSerializer>()
            .AddSingleton<ChangeEventDeserializer>()
            .AddTransient<IAggregateEventStreamWriter, AggregateEventStreamWriter>()
            .AddTransient<IAggregateEventStreamReader, AggregateEventStreamReader>();
        ;
    }
}