using Askedalen.ParkingApi.Domain.Entities.Enums;
using Askedalen.ParkingApi.Domain.Entities.ValueObjects;
using System;

namespace Askedalen.ParkingApi.Domain.Entities;

public class ParkingArea
{
    public Guid Id { get; init; }
    public int ExternalId { get; init; }
    public string Name { get; init; }
    public string Reference { get; init; }
    public string Address { get; init; }
    public City City { get; init; }
    public ParkingSpotsValue ParkingSpots { get; init; }
    public DateTime ActivationDate { get; init; }
    public DateTime LastUpdated { get; init; }
    public ParkingAreaType Type { get; init; }
    public bool ParkAndRide { get; init; }
    public CoordinateValue Coordinate { get; init;}
    public Organization ParkingProvider { get; init; }
    public Organization? ParkingEnforcer { get; init; }
    public bool IsActive { get; init; }

    public ParkingArea(
        Guid id,
        int externalId,
        string name,
        string reference,
        string address,
        City city,
        ParkingSpotsValue parkingSpots,
        DateTime activationDate,
        DateTime lastUpdated,
        ParkingAreaType type,
        bool parkAndRide,
        CoordinateValue coordinate,
        Organization parkingProvider,
        Organization parkingEnforcer,
        bool isActive)
    {
        Id = id;
        ExternalId = externalId;
        Name = name;
        Reference = reference;
        Address = address;
        City = city;
        ParkingSpots = parkingSpots;
        ActivationDate = activationDate;
        LastUpdated = lastUpdated;
        Type = type;
        ParkAndRide = parkAndRide;
        Coordinate = coordinate;
        ParkingProvider = parkingProvider;
        ParkingEnforcer = parkingEnforcer;
        IsActive = isActive;
    }

#pragma warning disable CS8618 // EF Core constructor
    private ParkingArea() { }
#pragma warning restore CS8618
}
