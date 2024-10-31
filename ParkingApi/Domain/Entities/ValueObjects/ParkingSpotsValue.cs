namespace Askedalen.ParkingApi.Domain.Entities.ValueObjects;

public class ParkingSpotsValue
{
    public int PaidSpots { get; }
    public int FreeSpots { get; }
    public int ChargingSpots { get; }
    public string? ChargingSpotsNote { get; }
    public int DisabledSpots { get; }
    public string? DisabledSpotsEvaluation { get; }

    public int TotalSpots => PaidSpots + FreeSpots + ChargingSpots + DisabledSpots;

    public static ParkingSpotsValue Create(
        int? paidSpots,
        int? freeSpots,
        int? chargingSpots,
        string? chargingSpotsNote,
        int? disabledSpots,
        string? disabledSpotsEvaluation)
        => new(
            paidSpots ?? 0,
            freeSpots ?? 0,
            chargingSpots ?? 0,
            chargingSpotsNote,
            disabledSpots ?? 0,
            disabledSpotsEvaluation
        );

    private ParkingSpotsValue(int paidSpots, int freeSpots, int chargingSpots,
        string? chargingSpotsNote, int disabledSpots, string? disabledSpotsEvaluation)
    {
        PaidSpots = paidSpots;
        FreeSpots = freeSpots;
        ChargingSpots = chargingSpots;
        ChargingSpotsNote = chargingSpotsNote;
        DisabledSpots = disabledSpots;
        DisabledSpotsEvaluation = disabledSpotsEvaluation;
    }
}
