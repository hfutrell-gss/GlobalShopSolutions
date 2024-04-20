using Modeling.Domain.Entities;

namespace Modeling.Application.Tests.TestCore.Domain;

public sealed class Garage : Entity<GarageId>
{
    public IReadOnlyCollection<Car> Cars => _cars;
    private List<Car> _cars;
    
    public Garage(GarageId id) : base(id)
    {
    }
}