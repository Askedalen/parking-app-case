using Askedalen.ParkingApi.Database;
using Askedalen.ParkingApi.ParkeringsRegisteret;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetValue<string>("DbConnectionString");
builder.Services.AddDbContext<ParkingDbContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddHttpClient();
builder.Services.AddTransient<ParkeringsRegisteretClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Run database migrations on startup
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

await app.Services.SeedParkeringsRegisteretData();

app.MapGet("/parking", async (ParkingDbContext dbContext) =>
{
    var parkings = await dbContext.ParkingAreas.ToListAsync();

    return Results.Ok();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


