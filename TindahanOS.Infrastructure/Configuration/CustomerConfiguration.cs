using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities.Customers;

namespace TindahanOS.Infrastructure.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        // Primary key
        builder.HasKey(x => x.Id);

        // Store relationship
        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // Customer information
        builder.Property(x => x.FullName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(x => x.Address)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(x => x.Notes)
            .HasMaxLength(500)
            .IsRequired(false);

        // Status: Active = 1, Inactive = 2
        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

        // Query indexes
        builder.HasIndex(x => x.StoreId);

        builder.HasIndex(x => new
        {
            x.StoreId,
            x.FullName
        });

        // Audit fields inherited from BaseAuditEntity
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false);

        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.Property(x => x.UpdatedBy)
            .IsRequired(false);
    }
}