using FastEndpoints;

namespace Modeling.Endpoints;

public abstract class ActionEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>;