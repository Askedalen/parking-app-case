using System.ComponentModel.DataAnnotations;

namespace Askedalen.ParkingApi.Domain.Entities.ValueObjects;

public class CoordinateValue
{
    private static readonly int minLatitude = -90;
    private static readonly int maxLatitude = 90;
    private static readonly int minLongitude = -180;
    private static readonly int maxLongitude = 180;

    public double Latitude { get; }
    public double Longitude { get; }

    public static CoordinateValue Create(double latitude, double longitude)
    {
        Validate(latitude, longitude);
        return new(latitude, longitude);
    }

    private static void Validate(double latitude, double longitude)
    {
        if (latitude < minLatitude || latitude > maxLatitude ||
            longitude < minLongitude || longitude > maxLongitude)
            throw new ValidationException("Coordinate out of bounds");
    }

    private CoordinateValue(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
