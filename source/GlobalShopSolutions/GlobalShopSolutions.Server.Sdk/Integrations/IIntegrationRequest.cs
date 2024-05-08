using MediatR;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Sdk.Integrations;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TIntegrationResponse"></typeparam>
public interface IIntegrationRequest<TIntegrationResponse> 
    : IRequest<Result<TIntegrationResponse>>
    where TIntegrationResponse : IIntegrationResponse;