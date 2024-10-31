using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Askedalen.ParkingApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddFacilitiesToParkingArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAccommodation",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBabyChangingTable",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBicycleParking",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHandicapToilet",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMotorcycleParking",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasShower",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasToilet",
                table: "ParkingAreas",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAccommodation",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasBabyChangingTable",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasBicycleParking",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasHandicapToilet",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasMotorcycleParking",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasShower",
                table: "ParkingAreas");

            migrationBuilder.DropColumn(
                name: "HasToilet",
                table: "ParkingAreas");
        }
    }
}
