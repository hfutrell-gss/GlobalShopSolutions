using Truss.Monads.Results;

namespace Modeling.Application.Cqrs.Commands;

/// <summary>
/// The bus that delivers commands through
/// the mediator
/// </summary>
/// <example>
/// If a command only returns a result
/// <code>
/// var cancelResult = await commandBus.SendCommand&lt;CancelOrderCommand&gt;(cancelOrderCommand, cancellationToken: ct);
/// </code>
///
/// If a command returns a value captured in a result
/// <code>
/// var cancelResult = await commandBus.SendCommand&lt;CancelOrderCommand, CancelOrderResponse&gt;(cancelOrderCommand, cancellationToken: ct);
/// </code>
/// </example>
public interface ICommandBus
{
    /// <summary>
    /// Dispatch a command to the bus
    /// </summary>
    public Task<Result<Nil>> SendCommand<TCommand>(
        TCommand command,
        CancellationToken cancellationToken = new()
    ) where TCommand : ICommand;

    /// <summary>
    /// Dispatch a command to the bus and return a value
    /// </summary>
    /// <returns>A specific type of <see cref="Result"/></returns>
    public Task<Result<TResult>> SendCommand<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken = new()
    )
        where TCommand : ICommand<TResult>;
}