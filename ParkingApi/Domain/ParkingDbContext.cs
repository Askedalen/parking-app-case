using Askedalen.ParkingApi.Domain.Entities;
using Askedalen.ParkingApi.Domain.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Askedalen.ParkingApi.Domain;

public class ParkingDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ParkingArea> ParkingAreas { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ParkingAreaConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
    }
}
