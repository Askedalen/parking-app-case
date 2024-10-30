using System;

namespace Askedalen.ParkingApi.Domain.Entities;

public class Organization
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string OrganizationNumber { get; init; }

    public Organization(Guid id, string name, string organizationNumber)
    {
        Id = id;
        Name = name;
        OrganizationNumber = organizationNumber;
    }

}
