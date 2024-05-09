using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.EfCore.Domain;

public sealed record CarId : EntityId<int>
{
    public CarId(int Value) : base(Value)
    {
    }
}