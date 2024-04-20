using Truss.Monads.Results;

namespace Modeling.Application.Cqrs.Commands;

/// <summary>
/// Command for CQRS that returns a <see cref="Result"/>
/// </summary>
public abstract record Command 
    : ICommand;

/// <summary>
/// Command for CQRS that returns a specific result type
/// </summary>
/// <typeparam name="TResult"></typeparam>
public abstract record Command<TResult> 
    : ICommand<TResult>;