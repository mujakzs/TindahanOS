using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class AuditLogConfiguration
    : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs", table =>
        {
            table.HasCheckConstraint(
                "CK_AuditLogs_ActionType_Valid",
                "[ActionType] IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10)");
        });

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StoreId)
            .IsRequired(false);

        builder.Property(x => x.UserId)
            .IsRequired(false);

        builder.Property(x => x.ActionType)
            .IsRequired();

        builder.Property(x => x.EntityName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.EntityId)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.IpAddress)
            .HasMaxLength(45)
            .IsRequired(false);

        builder.Property(x => x.OccurredAt)
            .IsRequired();

        // Common audit queries
        builder.HasIndex(x => new
        {
            x.StoreId,
            x.OccurredAt
        });

        builder.HasIndex(x => new
        {
            x.UserId,
            x.OccurredAt
        });

        builder.HasIndex(x => new
        {
            x.EntityName,
            x.EntityId
        });
    }
}