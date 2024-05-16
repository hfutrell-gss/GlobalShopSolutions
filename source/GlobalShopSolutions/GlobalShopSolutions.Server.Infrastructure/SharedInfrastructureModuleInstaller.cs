using GlobalShopSolutions.Server.Infrastructure.EventSourcing;
using GlobalShopSolutions.Server.Infrastructure.Messaging;
using GlobalShopSolutions.Server.Infrastructure.Validation;
using GlobalShopSolutions.Server.Sdk.Integrations;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Cqrs.Commands;
using Modeling.Application.Cqrs.EventSourcing.Reading;
using Modeling.Application.Cqrs.EventSourcing.Writing;
using Modeling.Application.Cqrs.Queries;
using Modeling.Application.Logging;
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
        InstallBuses(services);
        
        InstallEventSourcing(services);
        
        InstallLogging(services);
        
        InstallPipelineBehaviors(services);
    }

    private void InstallBuses(IServiceCollection services)
    {
        services
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDomainEventBus, DomainEventBus>()
            .AddTransient<IIntegrationBus, IntegrationBus>()
            .AddTransient<ICommandBus, CommandBus>()
            .AddTransient<IQueryBus, QueryBus>()
            ;
    }

    private void InstallEventSourcing(IServiceCollection services)
    {
        services
            .AddTransient<ChangeEventSerializer>()
            .AddTransient<ChangeEventDeserializer>()
            .AddTransient<IAggregateEventStreamWriter, AggregateEventStreamWriter>()
            .AddTransient<IAggregateEventStreamReader, AggregateEventStreamReader>()
            ;

    }

    private void InstallLogging(IServiceCollection services)
    {
        services.AddTransient<IDiagnosticLogger, DiagnosticLogger>();
    }
    
    /// <summary>
    /// The order matters hers. They will be executed from top
    /// to bottom and bottom to top
    /// </summary>
    /// <example>
    /// a -> b -> c -> command -> c -> b -> a
    /// </example>
    /// <param name="services"></param>
    private void InstallPipelineBehaviors(IServiceCollection services)
    {

        services
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}