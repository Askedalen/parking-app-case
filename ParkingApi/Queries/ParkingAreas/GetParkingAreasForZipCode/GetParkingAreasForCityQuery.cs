using Askedalen.ParkingApi.Domain;
using Askedalen.ParkingApi.Domain.Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Askedalen.ParkingApi.Queries.ParkingAreas;

public record GetParkingAreasForCityQuery(string City, FilterModel Filter) : IRequest<IEnumerable<GetParkingAreasForZipCodeResponse>>;
public class GetParkingAreasForZipCodeQueryHandler(ParkingDbContext dbContext)
: IRequestHandler<GetParkingAreasForCityQuery, IEnumerable<GetParkingAreasForZipCodeResponse>>
{
    public async Task<IEnumerable<GetParkingAreasForZipCodeResponse>> Handle(GetParkingAreasForCityQuery query,
        CancellationToken cancellationToken)
    {
        var responses = await dbContext.ParkingAreas
            .Include(parkingArea => parkingArea.City)
            .Where(parkingArea => parkingArea.City.Name == query.City)
            .WithFilter(query.Filter)
            .Select(parkingArea => new GetParkingAreasForZipCodeResponse(
                parkingArea.Id,
                parkingArea.Name,
                parkingArea.ParkingSpots.TotalSpots,
                parkingArea.Address,
                parkingArea.City.Name,
                parkingArea.ParkingSpots.PaidSpots,
                parkingArea.ParkingSpots.FreeSpots,
                parkingArea.ParkingSpots.ChargingSpots,
                parkingArea.ParkingSpots.ChargingSpotsNote,
                parkingArea.ParkingSpots.DisabledSpots,
                parkingArea.ParkingSpots.DisabledSpotsEvaluation,
                parkingArea.ParkAndRide,
                parkingArea.Facilities.HasToilet,
                parkingArea.Facilities.HasHandicapToilet,
                parkingArea.Facilities.HasBabyChangingTable,
                parkingArea.Facilities.HasShower,
                parkingArea.Facilities.HasAccommodation,
                parkingArea.Facilities.HasBicycleParking,
                parkingArea.Facilities.HasMotorcycleParking,
                parkingArea.ParkingProvider.Name,
                parkingArea.Type))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return responses;
    }
}

public record GetParkingAreasForZipCodeResponse(
    Guid Id,
    string Name,
    int TotalSpots,
    string? Address,
    string City,
    int? paidSpots,
    int? freeSpots,
    int? chargingSpots,
    string? chargingSpotsNote,
    int? disabledSpots,
    string? disabledSpotsEvaluation,
    bool ParkAndRide,
    bool? hasToilet,
    bool? hasHandicapToilet,
    bool? hasBabyChangingTable,
    bool? hasShower,
    bool? HasAccommodation,
    bool? HasBicycleParking,
    bool? HasMotorcycleParking,
    string Provider,
    ParkingAreaType ParkingAreaType
);
