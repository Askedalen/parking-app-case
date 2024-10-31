using Askedalen.ParkingApi.Domain;
using Askedalen.ParkingApi.Domain.Entities.Enums;
using Askedalen.ParkingApi.Domain.Entities.ValueObjects;
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
                parkingArea.Type))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return responses;
    }
}

public record GetParkingAreasForZipCodeResponse(Guid Id, string Name, int TotalSpots, ParkingAreaType ParkingAreaType);
