using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Dal.Configurations;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
        builder.Property(p => p.PhoneNumber).HasMaxLength(15).IsRequired();

        builder.HasMany(p => p.Invoices).WithOne();
    }
}
