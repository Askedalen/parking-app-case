using Askedalen.ParkingApi.Domain;
using Askedalen.ParkingApi.ParkeringsRegisteret;
using Askedalen.ParkingApi.Queries.ParkingAreas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetValue<string>("DbConnectionString");
builder.Services.AddDbContext<ParkingDbContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddHttpClient();
builder.Services.AddTransient<ParkeringsRegisteretClient>();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetParkingAreasForZipCodeQuery>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DisplayOperationId());

    // Run database migrations on startup
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ParkingDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

//await app.Services.SeedParkeringsRegisteretData();

app.MapParkingAreaEndpoints();

app.Run();


