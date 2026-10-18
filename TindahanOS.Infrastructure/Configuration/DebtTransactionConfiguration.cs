using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class DebtTransactionConfiguration
    : IEntityTypeConfiguration<DebtTransaction>
{
    public void Configure(EntityTypeBuilder<DebtTransaction> builder)
    {
        builder.ToTable("DebtTransactions");

        builder.HasKey(x => x.Id);

        // Debt account relationship
        builder.Property(x => x.DebtAccountId)
            .IsRequired();

        builder.HasOne(x => x.DebtAccount)
            .WithMany()
            .HasForeignKey(x => x.DebtAccountId)
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

        // Database-level check for positive amounts
        builder.ToTable("DebtTransactions", table =>
            table.HasCheckConstraint(
                "CK_DebtTransactions_Amount_Positive",
                "[Amount] > 0"));
    }
}