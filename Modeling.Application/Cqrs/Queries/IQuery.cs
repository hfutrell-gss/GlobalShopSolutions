using MediatR;
using Truss.Monads.Results;

namespace Modeling.Application.Cqrs.Queries;

public interface IQuery<T> 
    : IRequest<Result<T>>;