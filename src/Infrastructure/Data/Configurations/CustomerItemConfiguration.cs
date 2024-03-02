using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Infrastructure.Data.Configurations;
public class CustomerItemConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(t => t.CustomerId)
           .HasMaxLength(200)
           .IsRequired();

        builder.Property(t => t.FirstName)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.LastName)
           .HasMaxLength(200)
           .IsRequired();
        builder.Property(t => t.DateOfBirth)
           .HasMaxLength(200)
           .IsRequired();
        builder.Property(t => t.PhoneNumber)
           .HasMaxLength(200)
           .IsRequired();
        builder.Property(t => t.Email)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.BankAccountNumber)
           .HasMaxLength(200)
           .IsRequired();

    }
}
