namespace Askedalen.ParkingApi.ParkeringsRegisteret;

public static class ParkeringsRegisteretDataSeeder
{
    public async static Task SeedParkeringsRegisteretData(this IServiceProvider services)
    {
        var parkeringsRegisteretClient = services.GetRequiredService<ParkeringsRegisteretClient>();
        var parkingAreas = await parkeringsRegisteretClient.GetParkingAreas();

    }
}
