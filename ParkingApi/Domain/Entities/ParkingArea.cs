using Askedalen.ParkingApi.Domain.Entities.Enums;
using Askedalen.ParkingApi.Domain.Entities.ValueObjects;
using System;

namespace Askedalen.ParkingApi.Domain.Entities;

public class ParkingArea
{
    public Guid Id { get; }
    public int ExternalId { get; }
    public string Name { get; private set; }
    public string? Reference { get; private set; }
    public string? Address { get; private set; }
    public City City { get; }
    public ParkingSpotsValue ParkingSpots { get; private set; }
    public FacilitiesValue Facilities { get; private set; }
    public DateTime ActivationDate { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public ParkingAreaType Type { get; private set; }
    public bool ParkAndRide { get; private set; }
    public CoordinateValue Coordinate { get; private set; }
    public Organization ParkingProvider { get; }
    public Organization? ParkingEnforcer { get; private set; }
    public bool IsActive { get; private set; }

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
        Organization? parkingEnforcer,
        bool isActive)
    {
        Id = id;
        ExternalId = externalId;
        Name = name;
        Reference = reference;
        Address = address;
        City = city;
        ParkingSpots = parkingSpots;
        Facilities = FacilitiesValue.CreateEmpty();
        ActivationDate = activationDate;
        LastUpdated = lastUpdated;
        Type = type;
        ParkAndRide = parkAndRide;
        Coordinate = coordinate;
        ParkingProvider = parkingProvider;
        ParkingEnforcer = parkingEnforcer;
        IsActive = isActive;
    }

    public void Update(
        string name,
        string reference,
        string address,
        ParkingSpotsValue parkingSpots,
        DateTime lastUpdated,
        ParkingAreaType type,
        bool parkAndRide,
        CoordinateValue coordinate,
        Organization? parkingEnforcer,
        bool isActive)
    {
        Name = name;
        Reference = reference;
        Address = address;
        ParkingSpots = parkingSpots;
        LastUpdated = lastUpdated;
        Type = type;
        ParkAndRide = parkAndRide;
        Coordinate = coordinate;
        ParkingEnforcer = parkingEnforcer;
        IsActive = isActive;
    }

#pragma warning disable CS8618 // EF Core constructor
    private ParkingArea() { }
#pragma warning restore CS8618
}
