using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class StoreSettingsConfiguration
    : IEntityTypeConfiguration<StoreSetting>
{
    public void Configure(EntityTypeBuilder<StoreSetting> builder)
    {
        builder.ToTable("StoreSettings", table =>
        {
            table.HasCheckConstraint(
                "CK_StoreSettings_DebtDueDays_Range",
                "[DefaultDebtDueDays] BETWEEN 0 AND 365");
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithOne(x => x.Settings)
            .HasForeignKey<StoreSetting>(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // One settings record per store
        builder.HasIndex(x => x.StoreId)
            .IsUnique();

        builder.Property(x => x.CurrencyCode)
            .HasMaxLength(3)
            .HasDefaultValue("PHP")
            .IsRequired();

        builder.Property(x => x.TimeZoneId)
            .HasMaxLength(100)
            .HasDefaultValue("Asia/Manila")
            .IsRequired();

        builder.Property(x => x.AllowNegativeStock)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.RequireGCashVerification)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.DefaultDebtDueDays)
            .HasDefaultValue(0)
            .IsRequired();

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