using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modeling.Application.Tests.EfCore.Domain;

namespace Modeling.Application.Tests.EfCore.Persistence;

public sealed class GarageConfiguration
    : IEntityTypeConfiguration<Garage>
{
    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.ToTable("Garages");
                
        builder.HasKey(garage => garage.Id);
        
        builder.HasMany(garage => garage.Cars);

        builder.Property(garage => garage.Id)
            .HasConversion(
                id => id.Value,
                value => new GarageId(value)
            );

    }
}