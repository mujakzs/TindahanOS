using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class InventoryMovementConfiguration
    : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.ToTable("InventoryMovements", table =>
        {
            table.HasCheckConstraint(
                "CK_InventoryMovements_Quantity_Positive",
                "[Quantity] > 0");

            table.HasCheckConstraint(
                "CK_InventoryMovements_Type_Valid",
                "[MovementType] IN (1, 2, 3, 4, 5, 6)");
        });

        builder.HasKey(x => x.Id);

        // Store relationship
        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithMany(x => x.InventoryMovements)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // Product relationship
        builder.Property(x => x.ProductId)
            .IsRequired();

        // Enforce that the referenced product belongs to the same store by using a composite FK
        builder.HasOne(x => x.Product)
            .WithMany(x => x.InventoryMovements)
            .HasForeignKey(x => new { x.StoreId, x.ProductId })
            .HasPrincipalKey("StoreId", "Id")
            .OnDelete(DeleteBehavior.NoAction);

        // Movement type
        builder.Property(x => x.MovementType)
            .HasDefaultValue(1)
            .IsRequired();

        // Quantity: supports fractional units
        builder.Property(x => x.Quantity)
            .HasPrecision(18, 3)
            .IsRequired();

        builder.Property(x => x.ReferenceNumber)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Notes)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.MovementDate)
            .IsRequired();

        // Query indexes
        builder.HasIndex(x => new
        {
            x.StoreId,
            x.ProductId,
            x.MovementDate
        });

        builder.HasIndex(x => x.ReferenceNumber);

        // Audit fields
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