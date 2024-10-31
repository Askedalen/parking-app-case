using Askedalen.ParkingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Askedalen.ParkingApi.Domain.EntityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> city)
    {
        city.ToTable("Cities");
        city.HasKey(c => c.Id);
        city.Property(c => c.Id).ValueGeneratedNever();
        city.Property(c => c.Name).IsRequired();
        city.HasIndex(c => c.Name).IsUnique();
    }
}
