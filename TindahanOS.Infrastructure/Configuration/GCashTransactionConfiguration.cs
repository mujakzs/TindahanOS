using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class GCashTransactionConfiguration
    : IEntityTypeConfiguration<GCashTransaction>
{
    public void Configure(EntityTypeBuilder<GCashTransaction> builder)
    {
        builder.ToTable("GCashTransactions", table =>
        {
            table.HasCheckConstraint(
                "CK_GCashTransactions_Amount_Positive",
                "[Amount] > 0");

            table.HasCheckConstraint(
                "CK_GCashTransactions_Type_Valid",
                "[TransactionType] IN (1, 2)");

            table.HasCheckConstraint(
                "CK_GCashTransactions_Status_Valid",
                "[Status] IN (1, 2, 3, 4)");
        });

        builder.HasKey(x => x.Id);

        // Store relationship
        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithMany(x => x.GCashTransactions)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // Transaction type
        builder.Property(x => x.TransactionType)
            .HasDefaultValue(1)
            .IsRequired();

        // Customer information
        builder.Property(x => x.CustomerName)
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();

        // Amount
        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        // GCash reference
        builder.Property(x => x.ReferenceNumber)
            .HasMaxLength(100)
            .IsRequired(false);

        // Verification status
        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(x => x.Notes)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.TransactionDate)
            .IsRequired();

        // Search and duplicate investigation indexes
        builder.HasIndex(x => new
        {
            x.StoreId,
            x.ReferenceNumber
        });

        builder.HasIndex(x => new
        {
            x.StoreId,
            x.PhoneNumber,
            x.TransactionDate
        });

        builder.HasIndex(x => new
        {
            x.StoreId,
            x.Status,
            x.TransactionDate
        });

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