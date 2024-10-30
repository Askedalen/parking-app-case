﻿// <auto-generated />
using System;
using Askedalen.ParkingApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Askedalen.ParkingApi.Domain.Migrations
{
    [DbContext(typeof(ParkingDbContext))]
    partial class ParkingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Askedalen.ParkingApi.Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ZipCode")
                        .IsUnique();

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Askedalen.ParkingApi.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationNumber")
                        .IsUnique();

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("Askedalen.ParkingApi.Domain.Entities.ParkingArea", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParkAndRide")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParkingEnforcerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParkingProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ParkingEnforcerId");

                    b.HasIndex("ParkingProviderId");

                    b.ToTable("ParkingAreas", (string)null);
                });

            modelBuilder.Entity("Askedalen.ParkingApi.Domain.Entities.ParkingArea", b =>
                {
                    b.HasOne("Askedalen.ParkingApi.Domain.Entities.City", "City")
                        .WithMany("ParkingAreas")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Askedalen.ParkingApi.Domain.Entities.Organization", "ParkingEnforcer")
                        .WithMany()
                        .HasForeignKey("ParkingEnforcerId");

                    b.HasOne("Askedalen.ParkingApi.Domain.Entities.Organization", "ParkingProvider")
                        .WithMany()
                        .HasForeignKey("ParkingProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Askedalen.ParkingApi.Domain.Entities.ValueObjects.CoordinateValue", "Coordinate", b1 =>
                        {
                            b1.Property<Guid>("ParkingAreaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("ParkingAreaId");

                            b1.ToTable("ParkingAreas");

                            b1.WithOwner()
                                .HasForeignKey("ParkingAreaId");
                        });

                    b.OwnsOne("Askedalen.ParkingApi.Domain.Entities.ValueObjects.ParkingSpotsValue", "ParkingSpots", b1 =>
                        {
                            b1.Property<Guid>("ParkingAreaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ChargingSpots")
                                .HasColumnType("int")
                                .HasColumnName("ChargingSpots");

                            b1.Property<string>("ChargingSpotsNote")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ChargingSpotsNote");

                            b1.Property<int>("DisabledSpots")
                                .HasColumnType("int")
                                .HasColumnName("DisabledSpots");

                            b1.Property<string>("DisabledSpotsEvaluation")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DisabledSpotsEvaluation");

                            b1.Property<int>("FreeSpots")
                                .HasColumnType("int")
                                .HasColumnName("FreeSpots");

                            b1.Property<int>("PaidSpots")
                                .HasColumnType("int")
                                .HasColumnName("PaidSpots");

                            b1.HasKey("ParkingAreaId");

                            b1.ToTable("ParkingAreas");

                            b1.WithOwner()
                                .HasForeignKey("ParkingAreaId");
                        });

                    b.Navigation("City");

                    b.Navigation("Coordinate")
                        .IsRequired();

                    b.Navigation("ParkingEnforcer");

                    b.Navigation("ParkingProvider");

                    b.Navigation("ParkingSpots")
                        .IsRequired();
                });

            modelBuilder.Entity("Askedalen.ParkingApi.Domain.Entities.City", b =>
                {
                    b.Navigation("ParkingAreas");
                });
#pragma warning restore 612, 618
        }
    }
}
