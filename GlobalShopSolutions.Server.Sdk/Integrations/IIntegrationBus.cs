using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Sdk.Integrations;


/// <summary>
/// For transmitting Integration events and requests
/// </summary>
public interface IIntegrationBus
{
     /// <summary>
     /// Publishes the event to the bus
     /// </summary>
     /// <param name="integrationEvent"></param>
     /// <param name="cancellationToken"></param>
     /// <typeparam name="TIntegrationEvent"></typeparam>
     /// <returns></returns>
     Task Publish<TIntegrationEvent>(
         TIntegrationEvent integrationEvent,
         CancellationToken cancellationToken
     ) 
         where TIntegrationEvent : IIntegrationEvent;

     /// <summary>
     /// Sends a request to the integration bus and returns the response.
     /// </summary>
     /// <typeparam name="TIntegrationRequest">The type of the integration request.</typeparam>
     /// <typeparam name="TIntegrationResponse">The type of the integration response.</typeparam>
     /// <param name="integrationRequest">The integration request.</param>
     /// <param name="cancellationToken">The cancellation token.</param>
     /// <returns>The integration response.</returns>
     Task<Result<TIntegrationResponse>> Request<TIntegrationRequest, TIntegrationResponse>(
         TIntegrationRequest integrationRequest,
         CancellationToken cancellationToken
     ) 
         where TIntegrationRequest : IIntegrationRequest<TIntegrationResponse>
         where TIntegrationResponse : IIntegrationResponse;
}