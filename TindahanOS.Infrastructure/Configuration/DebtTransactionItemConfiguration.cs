using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class DebtTransactionItemConfiguration
    : IEntityTypeConfiguration<DebtTransactionItem>
{
    public void Configure(
        EntityTypeBuilder<DebtTransactionItem> builder)
    {
        builder.ToTable("DebtTransactionItems", table =>
        {
            table.HasCheckConstraint(
                "CK_DebtTransactionItems_Quantity_Positive",
                "[Quantity] > 0");

            table.HasCheckConstraint(
                "CK_DebtTransactionItems_UnitPrice_NonNegative",
                "[UnitPrice] >= 0");

            table.HasCheckConstraint(
                "CK_DebtTransactionItems_LineTotal_NonNegative",
                "[LineTotal] >= 0");
        });

        builder.HasKey(x => x.Id);

        // Parent transaction relationship
        builder.Property(x => x.DebtTransactionId)
            .IsRequired();

        builder.HasOne(x => x.DebtTransaction)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.DebtTransactionId)
            .OnDelete(DeleteBehavior.NoAction);

        // Product relationship
        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        // Quantity: supports fractional quantities
        builder.Property(x => x.Quantity)
            .HasPrecision(18, 3)
            .IsRequired();

        // Snapshot of the unit price at purchase time
        builder.Property(x => x.UnitPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        // Stored subtotal for this line
        builder.Property(x => x.LineTotal)
            .HasPrecision(18, 2)
            .IsRequired();

        // Query indexes
        builder.HasIndex(x => x.DebtTransactionId);

        builder.HasIndex(x => x.ProductId);

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