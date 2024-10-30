using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Askedalen.ParkingApi.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidSpots = table.Column<int>(type: "int", nullable: false),
                    FreeSpots = table.Column<int>(type: "int", nullable: false),
                    ChargingSpots = table.Column<int>(type: "int", nullable: false),
                    ChargingSpotsNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledSpots = table.Column<int>(type: "int", nullable: false),
                    DisabledSpotsEvaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ParkAndRide = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ParkingProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParkingEnforcerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingAreas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingAreas_Organizations_ParkingEnforcerId",
                        column: x => x.ParkingEnforcerId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParkingAreas_Organizations_ParkingProviderId",
                        column: x => x.ParkingProviderId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ZipCode",
                table: "Cities",
                column: "ZipCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationNumber",
                table: "Organizations",
                column: "OrganizationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingAreas_CityId",
                table: "ParkingAreas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingAreas_ExternalId",
                table: "ParkingAreas",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingAreas_ParkingEnforcerId",
                table: "ParkingAreas",
                column: "ParkingEnforcerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingAreas_ParkingProviderId",
                table: "ParkingAreas",
                column: "ParkingProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingAreas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
