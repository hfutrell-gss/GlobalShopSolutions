using GlobalShopSolutions.Server.Sdk.Integrations;
using MediatR;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Infrastructure.Buses;

/// <summary>
/// 
/// </summary>
public sealed class IntegrationBus : IIntegrationBus
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public IntegrationBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="integrationEvent"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent, CancellationToken cancellationToken) where TIntegrationEvent : IIntegrationEvent
    {
        await _mediator.Publish(integrationEvent, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="integrationRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TIntegrationRequest"></typeparam>
    /// <typeparam name="TIntegrationResponse"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Result<TIntegrationResponse>> Request<TIntegrationRequest, TIntegrationResponse>(TIntegrationRequest integrationRequest,
        CancellationToken cancellationToken) 
        where TIntegrationRequest : IIntegrationRequest<TIntegrationResponse> 
        where TIntegrationResponse : IIntegrationResponse
    {
        return await _mediator.Send(integrationRequest, cancellationToken);
    }
}