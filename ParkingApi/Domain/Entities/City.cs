﻿using System;
using System.Collections.Generic;

namespace Askedalen.ParkingApi.Domain.Entities;

public class City
{
    public Guid Id { get; }
    public string ZipCode { get; }
    public string Name { get; }

    public IReadOnlyList<ParkingArea> ParkingAreas = new List<ParkingArea>();

    public City(Guid id, string zipCode, string name)
    {
        Id = id;
        ZipCode = zipCode;
        Name = name;
    }

#pragma warning disable CS8618 // EF Core constructor
    private City() { }
#pragma warning restore CS8618 
}
