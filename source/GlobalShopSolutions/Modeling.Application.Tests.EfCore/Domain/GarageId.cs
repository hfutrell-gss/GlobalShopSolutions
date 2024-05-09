using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.EfCore.Domain;

public sealed record GarageId : EntityId<Guid>
{
    public GarageId(Guid Value) : base(Value)
    {
    }
}