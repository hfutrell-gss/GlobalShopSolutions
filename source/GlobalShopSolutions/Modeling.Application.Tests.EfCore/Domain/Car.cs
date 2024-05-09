using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.EfCore.Domain;

public sealed class Car : Entity<CarId>
{
    public Car(CarId id) : base(id)
    {
    }
}