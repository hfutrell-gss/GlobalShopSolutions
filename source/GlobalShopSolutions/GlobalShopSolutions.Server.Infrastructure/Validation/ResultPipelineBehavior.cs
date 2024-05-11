using System.Reflection;
using MediatR;
using Modeling.Application.Logging;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Infrastructure.Validation;

internal abstract class ResultPipelineBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IDiagnosticLogger _logger;
    private static Type ResultType => typeof(TResponse);
    
    protected bool IsResultType
    {
        get
        {
            if (ResultType == typeof(Result))
                return true;

            if (ResultType.IsGenericType
                && ResultType.GetGenericTypeDefinition() == typeof(Result<>))
                return true;

            return false;
        }
    }

    protected ResultPipelineBehavior(IDiagnosticLogger logger)
    {
        _logger = logger;
    }

    public abstract Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);

    protected TResponse Fail(params string[] reasons)
    {
        if (typeof(Result<>).IsAssignableFrom(typeof(TResponse))) throw new InvalidOperationException("Tried to fail a non-Result type.");
            
        var innerType = typeof(TResponse).GetGenericArguments()[0];
    
        var resultType = typeof(Result<>).MakeGenericType(innerType);
        var failMethod = resultType.GetMethod("Fail", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(FailureDetails) }, null);
        if (failMethod == null)
        {
            throw new InvalidOperationException("Fail method not found on Result type.");
        }
    
        var failureDetails = FailureDetails.From(reasons);
    
        return (TResponse)failMethod.Invoke(null, [failureDetails])!;
    }

    protected async Task ParseResult(TResponse result, Func<Task> onSuccess, Func<FailureDetails, Task> onFailure)
    {
        _logger.Log("Parsing result type");
        // Use reflection to get the IsSuccess or Succeeded property
        var successProperty = ResultType.GetProperty("Succeeded")!;

        bool wasSuccessful = (bool)successProperty.GetValue(result)!;

        _logger.Log("Result {WasOrWasNot} successful", wasSuccessful ? "was" : "was not");
        if (wasSuccessful)
        {
            await onSuccess().ConfigureAwait(false);
            
            return;
        }
        
        var failureDetailsProperty = ResultType.GetProperty("FailureDetails")!;

        var details = (FailureDetails) failureDetailsProperty.GetValue(result);

        _logger.Log("Result failed for {Reasons}", details.GetMessage());
        await onFailure(details).ConfigureAwait(false);
    }
}