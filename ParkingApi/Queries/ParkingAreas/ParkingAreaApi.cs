using Askedalen.ParkingApi.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Askedalen.ParkingApi.Queries.ParkingAreas;

public static class ParkingAreaApi
{
    public static void MapParkingAreaEndpoints(this WebApplication app)
    {
        var parkingAreaGroup = app.MapGroup("api/parking-area")
            .WithOpenApi()
            .WithTags("ParkingArea");

        parkingAreaGroup.MapGet("/city/{cityName}", async (
            [FromRoute] string cityName,
            [FromQuery] ParkingAreaType? parkingAreaType,
            [FromQuery] bool? parkAndRide,
            [FromQuery] bool? freeSpots,
            [FromQuery] bool? chargingSpots,
            [FromQuery] bool? disabledSpots,
            IMediator mediator) =>
        {
            var filter = FilterModel.Create(parkingAreaType, parkAndRide, freeSpots, chargingSpots, disabledSpots);
            var query = new GetParkingAreasForCityQuery(cityName, filter);
            var response = await mediator.Send(query);
            return response;
        })
        .WithOpenApi()
        .WithName("Get Parking Areas for Zip Code")
        .WithDescription("Returns a minimal response with parking areas for a given zip code.");
    }
}
