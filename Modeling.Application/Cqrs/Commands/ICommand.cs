using MediatR;
using Truss.Monads.Results;

namespace Modeling.Application.Cqrs.Commands;

/// <summary>
/// 
/// </summary>
public interface ICommand : IRequest<Result<Nil>>;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface ICommand<TResult> : IRequest<Result<TResult>>;