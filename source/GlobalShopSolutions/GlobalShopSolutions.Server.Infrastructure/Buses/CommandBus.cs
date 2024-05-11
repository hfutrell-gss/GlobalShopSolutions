using MediatR;
using Modeling.Application.Cqrs.Commands;
using Truss.Monads.Results;

namespace GlobalShopSolutions.Server.Infrastructure.Buses;

public sealed class CommandBus : ICommandBus
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public CommandBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand"></typeparam>
    /// <returns></returns>
    public async Task<Result<Nil>> SendCommand<TCommand>(
        TCommand command,
        CancellationToken cancellationToken
    ) where TCommand : ICommand
    {
        return await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public async Task<Result<TResult>> SendCommand<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken
    ) where TCommand : ICommand<TResult>
    {
        return await _mediator.Send(command, cancellationToken);
    }
}