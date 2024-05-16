using MediatR;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Sdk.Integrations;

public interface IIntegrationRequestHandler<in TIntegrationRequest, TIntegrationResponse> 
    : IRequestHandler<TIntegrationRequest, Result<TIntegrationResponse>>
    where TIntegrationRequest : IIntegrationRequest<TIntegrationResponse>;