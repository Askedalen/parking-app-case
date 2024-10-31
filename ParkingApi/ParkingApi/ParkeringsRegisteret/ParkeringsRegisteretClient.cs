namespace Askedalen.ParkingApi.ParkeringsRegisteret;

public class ParkeringsRegisteretClient(IHttpClientFactory httpClientFactory)
{

    public async Task<IEnumerable<ParkeringsomradeResponse>> GetParkingAreas()
    {
        var httpClient = GetHttpClient();
        var response = await httpClient.GetAsync("parkeringsomraade?datafelter=alle");
        response.EnsureSuccessStatusCode();

        var parkingAreas = await response.Content.ReadFromJsonAsync<IEnumerable<ParkeringsomradeResponse>>();
        if (parkingAreas == null)
            throw new ApplicationException("Failed to fetch parking areas");

        return parkingAreas;
    }

    private HttpClient GetHttpClient()
    {
        var httpClient = httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("https://parkreg-open.atlas.vegvesen.no/ws/no/vegvesen/veg/parkeringsomraade/parkeringsregisteret/v1/");
        return httpClient;
    }
}

public record ParkeringsomradeResponse(
    int Id,
    int ParkeringstilbyderId,
    string ParkeringstilbyderNavn,
    string ParkeringstilbyderOrganisasjonsnummer,
    double Breddegrad,
    double Lengdegrad,
    DeaktivertResponse? Deaktivert,
    ParkeringsomradeVersjonResponse AktivVersjon
);

public record DeaktivertResponse(DateTime DeaktivertTidspunkt);

public record ParkeringsomradeVersjonResponse(
    string Navn,
    string Referanse,
    string Adresse,
    string Postnummer,
    string Poststed,
    int? AntallAvgiftsbelagtePlasser,
    int? AntallAvgiftsfriePlasser,
    int? AntallLadeplasser,
    string MerknadLadeplasser,
    int? AntallForflytningshemmede,
    string VurderingForflytningshemmede,
    DateTime Aktiveringstidspunkt,
    DateTime SistEndret,
    int? Versjonsnummer,
    DateTime? Sluttidspunkt,
    int? OpplastetVurderingId,
    string TypeParkeringsomrade,
    string Innfartsparkering,
    HandheverResponse? Handhever
);

public record HandheverResponse(
  string Organisasjonsnummer,
  string Navn
);
