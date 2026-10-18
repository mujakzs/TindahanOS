using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class DebtAccountConfiguration
    : IEntityTypeConfiguration<DebtAccount>
{
    public void Configure(EntityTypeBuilder<DebtAccount> builder)
    {
        builder.ToTable("DebtAccounts");

        builder.HasKey(x => x.Id);

        // Allow other entities to reference (StoreId, Id)
        builder.HasAlternateKey(x => new { x.StoreId, x.Id });

        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

        builder.Property(x => x.Notes)
            .HasMaxLength(500)
            .IsRequired(false);

        // A customer can have at most one debt account per store.
        builder.HasIndex(x => new
        {
            x.StoreId,
            x.CustomerId
        })
        .IsUnique();

        builder.HasIndex(x => x.StoreId);

        builder.HasOne(x => x.Store)
            .WithMany()
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        // Enforce that the referenced customer belongs to the same store by using a composite FK
        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => new { x.StoreId, x.CustomerId })
            .HasPrincipalKey("StoreId", "Id")
            .OnDelete(DeleteBehavior.NoAction);

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