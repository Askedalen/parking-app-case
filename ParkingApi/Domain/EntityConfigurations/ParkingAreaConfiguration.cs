using Askedalen.ParkingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Askedalen.ParkingApi.Domain.EntityConfigurations
{
    public class ParkingAreaConfiguration : IEntityTypeConfiguration<ParkingArea>
    {
        public void Configure(EntityTypeBuilder<ParkingArea> parkingArea)
        {
            parkingArea.ToTable("ParkingAreas");
            parkingArea.HasKey(p => p.Id);
            parkingArea.Property(p => p.Id).ValueGeneratedNever();
            parkingArea.Property(p => p.ExternalId).IsRequired();
            parkingArea.HasIndex(p => p.ExternalId).IsUnique();
            parkingArea.Property(p => p.Name).IsRequired();
            parkingArea.Property(p => p.Reference);
            parkingArea.Property(p => p.Address);
            parkingArea.HasOne(p => p.City).WithMany();
            parkingArea.OwnsOne(p => p.ParkingSpots, parkingSpots =>
            {
                parkingSpots.Property(p => p.PaidSpots).HasColumnName("PaidSpots").IsRequired();
                parkingSpots.Property(p => p.FreeSpots).HasColumnName("FreeSpots").IsRequired();
                parkingSpots.Property(p => p.ChargingSpots).HasColumnName("ChargingSpots").IsRequired();
                parkingSpots.Property(p => p.ChargingSpotsNote).HasColumnName("ChargingSpotsNote");
                parkingSpots.Property(p => p.DisabledSpots).HasColumnName("DisabledSpots").IsRequired();
                parkingSpots.Property(p => p.DisabledSpotsEvaluation).HasColumnName("DisabledSpotsEvaluation");
            });
            parkingArea.OwnsOne(p => p.Facilities, facilities =>
            {
                facilities.Property(f => f.HasToilet).HasColumnName("HasToilet");
                facilities.Property(f => f.HasHandicapToilet).HasColumnName("HasHandicapToilet");
                facilities.Property(f => f.HasBabyChangingTable).HasColumnName("HasBabyChangingTable");
                facilities.Property(f => f.HasShower).HasColumnName("HasShower");
                facilities.Property(f => f.HasAccommodation).HasColumnName("HasAccommodation");
                facilities.Property(f => f.HasBicycleParking).HasColumnName("HasBicycleParking");
                facilities.Property(f => f.HasMotorcycleParking).HasColumnName("HasMotorcycleParking");
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
        }
    }
}
