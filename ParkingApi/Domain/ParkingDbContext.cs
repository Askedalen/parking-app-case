using Askedalen.ParkingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Askedalen.ParkingApi.Database;

public class ParkingDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ParkingArea> ParkingAreas { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ParkingArea>(parkingArea =>
        {
            parkingArea.ToTable("ParkingAreas");
            parkingArea.HasKey(p => p.Id);
            parkingArea.Property(p => p.Id).ValueGeneratedNever();
            parkingArea.Property(p => p.ExternalId).IsRequired();
            parkingArea.HasIndex(p => p.ExternalId).IsUnique();
            parkingArea.Property(p => p.Name).IsRequired();
            parkingArea.Property(p => p.Reference).IsRequired();
            parkingArea.Property(p => p.Address).IsRequired();
            parkingArea.HasOne(p => p.City).WithMany(c => c.ParkingAreas);
            parkingArea.OwnsOne(p => p.ParkingSpots, parkingSpots =>
            {
                parkingSpots.Property(p => p.PaidSpots).HasColumnName("PaidSpots").IsRequired();
                parkingSpots.Property(p => p.FreeSpots).HasColumnName("FreeSpots").IsRequired();
                parkingSpots.Property(p => p.ChargingSpots).HasColumnName("ChargingSpots").IsRequired();
                parkingSpots.Property(p => p.ChargingSpotsNote).HasColumnName("ChargingSpotsNote");
                parkingSpots.Property(p => p.DisabledSpots).HasColumnName("DisabledSpots").IsRequired();
                parkingSpots.Property(p => p.DisabledSpotsEvaluation).HasColumnName("DisabledSpotsEvaluation");
            });
            parkingArea.Property(p => p.ActivationDate).IsRequired();
            parkingArea.Property(p => p.LastUpdated).IsRequired();
            parkingArea.Property(p => p.Type).IsRequired();
            parkingArea.Property(p => p.ParkAndRide).IsRequired();
            parkingArea.OwnsOne(p => p.Coordinate, coordinate =>
            {
                coordinate.Property(c => c.Latitude).HasColumnName("Latitude").IsRequired();
                coordinate.Property(c => c.Longitude).HasColumnName("Longitude").IsRequired();
            });
            parkingArea.HasOne(p => p.ParkingProvider).WithMany();
            parkingArea.HasOne(p => p.ParkingEnforcer).WithMany();
            parkingArea.Property(p => p.IsActive).IsRequired();
        });

        modelBuilder.Entity<City>(city =>
        {
            city.ToTable("Cities");
            city.HasKey(c => c.Id);
            city.Property(c => c.Id).ValueGeneratedNever();
            city.Property(c => c.ZipCode).IsRequired();
            city.HasIndex(c => c.ZipCode).IsUnique();
            city.Property(c => c.Name).IsRequired();
        });

        modelBuilder.Entity<Organization>(organization => {
            organization.ToTable("Organizations");
            organization.HasKey(pe => pe.Id);
            organization.Property(pe => pe.Id).ValueGeneratedNever();
            organization.Property(pe => pe.Name).IsRequired();
            organization.Property(pp => pp.OrganizationNumber).IsRequired();
            organization.HasIndex(pp => pp.OrganizationNumber).IsUnique();
        });
    }
}
