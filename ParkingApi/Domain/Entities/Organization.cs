using System;

namespace Askedalen.ParkingApi.Domain.Entities;

public class Organization
{
    public Guid Id { get; }
    public string Name { get; }
    public string OrganizationNumber { get; }

    public Organization(Guid id, string name, string organizationNumber)
    {
        Id = id;
        Name = name;
        OrganizationNumber = organizationNumber;
    }
}
