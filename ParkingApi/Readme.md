# ParkingApi
## Entity Framework migrations
To create a new migration, run the following command:
```
	dotnet ef migrations add Initial -s ParkingApi/ParkingApi.csproj -p Domain/Domain.csproj
```

To remove a migration, run the following command:
```
	dotnet ef migrations remove --force -s ParkingApi/ParkingApi.csproj -p Domain/Domain.csproj
```

To apply a migration, run the following command:
```
	dotnet ef database update --connection "Server=localhost,1433;Database=parking;User Id=sa;Password=superSecurePassword!;Trust Server Certificate=true;" -s ParkingApi/ParkingApi.csproj -p Domain/Domain.csproj
```