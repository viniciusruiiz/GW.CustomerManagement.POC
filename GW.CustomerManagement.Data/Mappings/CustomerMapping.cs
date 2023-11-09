using GW.CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GW.CustomerManagement.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Name)
            .Property(p => p.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.OwnsOne(p => p.Name)
            .Property(p => p.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.RG)
            .HasMaxLength(9)
            .IsRequired();

        builder.OwnsOne(p => p.CPF)
            .Property(p => p.Value)
            .HasMaxLength(11)
            .IsRequired();

        builder.OwnsOne(p => p.Address)
            .Property(p => p.Street)
            .HasMaxLength(255)
            .IsRequired();

        builder.OwnsOne(p => p.Address)
            .Property(p => p.City)
            .HasMaxLength(255)
            .IsRequired();

        builder.OwnsOne(p => p.Address)
            .Property(p => p.State)
            .HasMaxLength(255)
            .IsRequired();

        builder.OwnsOne(p => p.Address)
            .Property(p => p.Number)
            .HasMaxLength(32)
            .IsRequired();

        builder.OwnsOne(p => p.Address)
            .Property(p => p.PostalCode)
            .HasMaxLength(9)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .IsRequired();
    }
}
