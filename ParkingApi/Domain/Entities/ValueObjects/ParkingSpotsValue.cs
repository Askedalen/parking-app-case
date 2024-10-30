namespace Askedalen.ParkingApi.Domain.Entities.ValueObjects;

public class ParkingSpotsValue
{
    public int PaidSpots { get; init; }
    public int FreeSpots { get; init; }
    public int ChargingSpots { get; init; }
    public string? ChargingSpotsNote { get; init; }
    public int DisabledSpots { get; init; }
    public string? DisabledSpotsEvaluation { get; init; }

    public static ParkingSpotsValue Create(
        int? paidSpots,
        int? freeSpots,
        int? chargingSpots,
        string? chargingSpotsNote,
        int? disabledSpots,
        string? disabledSpotsEvaluation)
        => new()
        {
            PaidSpots = paidSpots ?? 0,
            FreeSpots = freeSpots ?? 0,
            ChargingSpots = chargingSpots ?? 0,
            ChargingSpotsNote = chargingSpotsNote,
            DisabledSpots = disabledSpots ?? 0,
            DisabledSpotsEvaluation = disabledSpotsEvaluation
        };
}
