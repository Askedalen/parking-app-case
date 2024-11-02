namespace Askedalen.ParkingApi.Domain.Entities.ValueObjects;

public class FacilitiesValue
{
    public bool? HasToilet { get; }
    public bool? HasHandicapToilet { get; }
    public bool? HasBabyChangingTable { get; }
    public bool? HasShower { get; }
    public bool? HasAccommodation { get; }
    public bool? HasBicycleParking { get; }
    public bool? HasMotorcycleParking { get; }

    public static FacilitiesValue Create(
        bool? hasToilet,
        bool? hasHandicapToilet,
        bool? hasBabyChangingTable,
        bool? hasShower,
        bool? hasAccommodation,
        bool? hasBicycleParking,
        bool? hasMotorcycleParking)
        => new(
            hasToilet,
            hasHandicapToilet,
            hasBabyChangingTable,
            hasShower,
            hasAccommodation,
            hasBicycleParking,
            hasMotorcycleParking
        );

    public static FacilitiesValue CreateEmpty() => new(null, null, null, null, null, null, null);

    private FacilitiesValue(bool? hasToilet, bool? hasHandicapToilet, bool? hasBabyChangingTable, bool? hasShower,
        bool? hasAccommodation, bool? hasBicycleParking, bool? hasMotorcycleParking)
    {
        HasToilet = hasToilet;
        HasHandicapToilet = hasHandicapToilet;
        HasBabyChangingTable = hasBabyChangingTable;
        HasShower = hasShower;
        HasAccommodation = hasAccommodation;
        HasBicycleParking = hasBicycleParking;
        HasMotorcycleParking = hasMotorcycleParking;
    }
}
