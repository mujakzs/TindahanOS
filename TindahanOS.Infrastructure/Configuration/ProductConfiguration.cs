using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class ProductConfiguration
    : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", table =>
        {
            table.HasCheckConstraint(
                "CK_Products_Unit_Valid",
                "[Unit] IN (1,2,3,4,5,6,7,8,9,10)");

            table.HasCheckConstraint(
                "CK_Products_Status_Valid",
                "[Status] IN (1,2)");

            table.HasCheckConstraint(
                "CK_Products_SellingPrice_NonNegative",
                "[SellingPrice] >= 0");

            table.HasCheckConstraint(
                "CK_Products_CostPrice_NonNegative",
                "[CostPrice] IS NULL OR [CostPrice] >= 0");
        });

        // Primary key
        builder.HasKey(x => x.Id);

        // Store relationship
        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // Allow referencing by (StoreId, Id) to enforce tenant ownership from dependents
        builder.HasAlternateKey(x => new { x.StoreId, x.Id });

        // Product information
        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.SKU)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired(false);

        // Unit: Piece = 1 by default
        builder.Property(x => x.Unit)
            .HasDefaultValue(1)
            .IsRequired();

        // Monetary values
        builder.Property(x => x.SellingPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.CostPrice)
            .HasPrecision(18, 2)
            .IsRequired(false);

        // Status: Active = 1 by default
        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

        // Indexes
        builder.HasIndex(x => x.StoreId);

        builder.HasIndex(x => new
        {
            x.StoreId,
            x.Name
        });

        // SKU must be unique within a store when provided.
        // SQL Server filtered index allows multiple null SKUs.
        builder.HasIndex(x => new
        {
            x.StoreId,
            x.SKU
        })
        .IsUnique()
        .HasFilter("[SKU] IS NOT NULL");

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