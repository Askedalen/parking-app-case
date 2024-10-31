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

public record GetParkingAreasForZipCodeQuery(string ZipCode, FilterModel Filter) : IRequest<IEnumerable<GetParkingAreasForZipCodeResponse>>
{
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ZipCode))
            throw new ArgumentException("Zip code cannot be empty.");
        if (ZipCode.Length != 4)
            throw new ArgumentException("Zip code must be 4 characters long.");
        if (!ZipCode.All(char.IsDigit))
            throw new ArgumentException("Zip code must be numeric.");
    }
}

public class GetParkingAreasForZipCodeQueryHandler(ParkingDbContext dbContext)
: IRequestHandler<GetParkingAreasForZipCodeQuery, IEnumerable<GetParkingAreasForZipCodeResponse>>
{
    public async Task<IEnumerable<GetParkingAreasForZipCodeResponse>> Handle(GetParkingAreasForZipCodeQuery query,
        CancellationToken cancellationToken)
    {
        query.Validate();

        var responses = await dbContext.ParkingAreas
            .Include(parkingArea => parkingArea.City)
            .Where(parkingArea => parkingArea.City.ZipCode == query.ZipCode)
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
