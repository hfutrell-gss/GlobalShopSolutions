using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Modeling.Application.Logging;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Infrastructure.Validation;

internal sealed class ValidationPipelineBehavior<TRequest, TResponse> 
    : ResultPipelineBehavior<TRequest, TResponse>
    where TResponse : IResult where TRequest : notnull
{
    private readonly IServiceProvider _provider;

    public ValidationPipelineBehavior(
        IDiagnosticLogger logger,
        IServiceProvider provider
    ) : base(logger)
    {
        _provider = provider;
    }

    public override async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var validator = _provider
            .GetService<IValidator<TRequest>>();

        if (validator is null) return await next();

        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.IsValid) return await next();
        
        return Fail(string.Join(". ", result.Errors.Select(
            error => error.ErrorMessage)));
    }

}