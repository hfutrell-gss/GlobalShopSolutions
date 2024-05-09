using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.EfCore.Domain;

public sealed record AutoShopId 
    : AggregateRootId<Guid>
{
    public AutoShopId(Guid Value) : base(Value)
    {
    }
}