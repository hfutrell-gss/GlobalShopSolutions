using MediatR;
using Truss.Monads.Results;

namespace Modeling.Application.Integrations;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TIntegrationResponse"></typeparam>
public interface IIntegrationRequest<TIntegrationResponse> 
    : IRequest<Result<TIntegrationResponse>>
    where TIntegrationResponse : IIntegrationResponse;