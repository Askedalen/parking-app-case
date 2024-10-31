using Askedalen.ParkingApi.Domain;
using Askedalen.ParkingApi.Domain.Entities;
using Askedalen.ParkingApi.Domain.Entities.Enums;
using Askedalen.ParkingApi.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Askedalen.ParkingApi.ParkeringsRegisteret;

public static class ParkeringsRegisteretDataSeeder
{
    public async static Task SeedParkeringsRegisteretData(this IServiceProvider services)
    {
        var parkeringsRegisteretClient = services.GetRequiredService<ParkeringsRegisteretClient>();
        var parkingAreaResponses = await parkeringsRegisteretClient.GetParkingAreas();

        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();

        var parkingAreas = await dbContext.ParkingAreas.ToListAsync();
        var cities = await dbContext.Cities.ToListAsync();
        var organizations = await dbContext.Organizations.ToListAsync();

        foreach (var response in parkingAreaResponses)
        {
            var activeVersion = response.AktivVersjon;
            var parkingArea = parkingAreas.FirstOrDefault(p => p.ExternalId == response.Id);
            if (parkingArea != null)
            {
                UpdateParkingArea(response, parkingArea, organizations, dbContext);
            }
            else
            {
                CreateParkingArea(response, organizations, cities, dbContext);
            }
        }

        await dbContext.SaveChangesAsync();
    }

    private static void UpdateParkingArea(ParkeringsomradeResponse response, ParkingArea parkingArea,
        List<Organization> organizations, ParkingDbContext dbContext)
    {
        var activeVersion = response.AktivVersjon;

        if (activeVersion.SistEndret <= parkingArea.LastUpdated)
            return;

        var parkingSpotsValue = CreateParkingSpotsValue(activeVersion);
        var parkingAreaType = GetParkingAreaType(activeVersion.TypeParkeringsomrade);
        var parkAndRide = activeVersion.Innfartsparkering == "JA";
        var parkingEnforcer = GetOrCreateOrganization(activeVersion.Handhever?.Navn,
            activeVersion.Handhever?.Organisasjonsnummer, organizations, dbContext);
        var coordinate = CoordinateValue.Create(response.Breddegrad, response.Lengdegrad);

        parkingArea.Update(activeVersion.Navn, activeVersion.Referanse, activeVersion.Adresse, parkingSpotsValue, activeVersion.SistEndret,
            parkingAreaType, parkAndRide, coordinate, parkingEnforcer, response.Deaktivert != null);
    }

    private static void CreateParkingArea(ParkeringsomradeResponse response, List<Organization> organizations,
        List<City> cities, ParkingDbContext dbContext)
    {
        var activeVersion = response.AktivVersjon;

        var city = GetOrCreateCity(activeVersion, cities, dbContext);
        var parkingProvider = GetOrCreateOrganization(response.ParkeringstilbyderNavn,
            response.ParkeringstilbyderOrganisasjonsnummer, organizations, dbContext);
        var parkingEnforcer = GetOrCreateOrganization(activeVersion.Handhever?.Navn,
            activeVersion.Handhever?.Organisasjonsnummer, organizations, dbContext);
        var parkingSpotsValue = CreateParkingSpotsValue(activeVersion);
        var parkingAreaType = GetParkingAreaType(activeVersion.TypeParkeringsomrade);
        var parkAndRide = activeVersion.Innfartsparkering == "JA";
        var coordinate = CoordinateValue.Create(response.Breddegrad, response.Lengdegrad);

        var parkingArea = new ParkingArea(Guid.NewGuid(), response.Id, activeVersion.Navn, activeVersion.Referanse,
            activeVersion.Adresse, city, parkingSpotsValue, activeVersion.Aktiveringstidspunkt, activeVersion.SistEndret,
            parkingAreaType, parkAndRide, coordinate, parkingProvider!, parkingEnforcer, response.Deaktivert != null);

        dbContext.Add(parkingArea);
    }

    private static ParkingSpotsValue CreateParkingSpotsValue(dynamic activeVersion) =>
        ParkingSpotsValue.Create(activeVersion.AntallAvgiftsbelagtePlasser, activeVersion.AntallAvgiftsfriePlasser,
            activeVersion.AntallLadeplasser, activeVersion.MerknadLadeplasser, activeVersion.AntallForflytningshemmede,
            activeVersion.VurderingForflytningshemmede);

    private static ParkingAreaType GetParkingAreaType(string typeParkeringsomrade) =>
        Enum.TryParse<ParkingAreaType>(typeParkeringsomrade, true, out var parkingAreaType) ? parkingAreaType : ParkingAreaType.IKKE_VALGT;

    private static Organization? GetOrCreateOrganization(string? organizationName, string? organizationNumber, List<Organization> organizations, ParkingDbContext dbContext)
    {
        if (organizationNumber == null || organizationName == null)
            return null;

        var organization = organizations.FirstOrDefault(o => o.OrganizationNumber == organizationNumber);
        if (organization == null)
        {
            organization = new Organization(Guid.NewGuid(), organizationName, organizationNumber);
            organizations.Add(organization);
            dbContext.Add(organization);
        }

        return organization;
    }

    private static City GetOrCreateCity(dynamic activeVersion, List<City> cities, ParkingDbContext dbContext)
    {
        var city = cities.FirstOrDefault(c => c.ZipCode == activeVersion.Postnummer);
        if (city == null)
        {
            city = new City(Guid.NewGuid(), activeVersion.Postnummer, activeVersion.Poststed);
            cities.Add(city);
            dbContext.Add(city);
        }

        return city;
    }
}
