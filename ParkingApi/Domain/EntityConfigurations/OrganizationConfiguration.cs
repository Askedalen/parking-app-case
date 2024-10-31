using Askedalen.ParkingApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Askedalen.ParkingApi.Domain.EntityConfigurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> organization)
    {
        organization.ToTable("Organizations");
        organization.HasKey(pe => pe.Id);
        organization.Property(pe => pe.Id).ValueGeneratedNever();
        organization.Property(pe => pe.Name).IsRequired();
        organization.Property(pp => pp.OrganizationNumber).IsRequired();
        organization.HasIndex(pp => pp.OrganizationNumber).IsUnique();
    }
}
