using MediatR;

namespace GlobalShopSolutions.Server.Sdk.Integrations;

/// <summary>
/// 
/// </summary>
public interface IIntegrationEvent : INotification;

public interface IIntegrationEvenHandler<in TIntegrationEvent>  : INotificationHandler<TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent;