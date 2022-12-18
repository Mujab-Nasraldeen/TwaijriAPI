using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Dal.Configurations;
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable(nameof(Invoice));
        builder.HasKey(p => p.Id);

        builder.Property(p => p.InvoiceDate).IsRequired();
        builder.Property(p => p.Value).IsRequired();
        builder.Property(p => p.State).IsRequired();
    }
}
