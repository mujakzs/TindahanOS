using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class DebtTransactionConfiguration
    : IEntityTypeConfiguration<DebtTransaction>
{
    public void Configure(EntityTypeBuilder<DebtTransaction> builder)
    {
        builder.ToTable("DebtTransactions", table =>
        {
            table.HasCheckConstraint(
                "CK_DebtTransactions_Amount_Positive",
                "[Amount] > 0");
        });

        builder.HasKey(x => x.Id);

        // StoreId on DebtTransaction to enforce tenant ownership when referencing from items
        builder.Property(x => x.StoreId)
            .IsRequired();

        // Allow other entities (items) to reference (StoreId, Id)
        builder.HasAlternateKey(x => new { x.StoreId, x.Id });

        // Debt account relationship
        builder.Property(x => x.DebtAccountId)
            .IsRequired();

        // Enforce that the referenced debt account belongs to the same store by using a composite FK
        builder.HasOne(x => x.DebtAccount)
            .WithMany()
            .HasForeignKey(x => new { x.StoreId, x.DebtAccountId })
            .HasPrincipalKey("StoreId", "Id")
            .OnDelete(DeleteBehavior.NoAction);

        // Transaction type
        builder.Property(x => x.Type)
            .HasDefaultValue(1)
            .IsRequired();

        // Monetary amount
        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        // Transaction date
        builder.Property(x => x.TransactionDate)
            .IsRequired();

        // Optional reference
        builder.Property(x => x.ReferenceNumber)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Notes)
            .HasMaxLength(500)
            .IsRequired(false);

        // Indexes for account history and reporting
        builder.HasIndex(x => new
        {
            x.DebtAccountId,
            x.TransactionDate
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

        // Database-level checks were consolidated into the initial ToTable call above.
    }
}