using MediatR;

namespace GlobalShopSolutions.Server.Sdk.Integrations;

public interface IIntegrationEventHandler<in TIntegrationEvent>  : INotificationHandler<TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent;