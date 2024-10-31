using Askedalen.ParkingApi.Domain.Entities;
using Askedalen.ParkingApi.Domain.Entities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Askedalen.ParkingApi.Queries;

public static class ParkingAreaFilter
{
    public static IQueryable<ParkingArea> WithFilter(this IQueryable<ParkingArea> parkingAreas, FilterModel filter)
    {
        if (filter.Type.HasValue)
            parkingAreas = parkingAreas.Where(parkingArea => parkingArea.Type == filter.Type);
        if (filter.ParkAndRide)
            parkingAreas = parkingAreas.Where(parkingArea => parkingArea.ParkAndRide);
        if (filter.FreeSpots)
            parkingAreas = parkingAreas.Where(parkingArea => parkingArea.ParkingSpots.FreeSpots > 0);
        if (filter.ChargingSpots)
            parkingAreas = parkingAreas.Where(parkingArea => parkingArea.ParkingSpots.ChargingSpots > 0);
        if (filter.DisabledSpots)
            parkingAreas = parkingAreas.Where(parkingArea => parkingArea.ParkingSpots.DisabledSpots > 0);

        return parkingAreas;
    }
}

public record FilterModel(ParkingAreaType? Type, bool ParkAndRide, bool FreeSpots, bool ChargingSpots, bool DisabledSpots)
{
    public static FilterModel Create(ParkingAreaType? type, bool? parkAndRide, bool? freeSpots, bool? chargingSpots, bool? disabledSpots) =>
        new(
            type.HasValue ? type.Value : null,
            parkAndRide ?? false,
            freeSpots ?? false,
            chargingSpots ?? false,
            disabledSpots ?? false
        );
}
