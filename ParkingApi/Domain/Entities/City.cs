using System;

namespace Askedalen.ParkingApi.Domain.Entities;

public class City
{
    public Guid Id { get; }
    public string Name { get; }

    public City(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
