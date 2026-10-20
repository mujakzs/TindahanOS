using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Extension;

public static class AuditConfigurationExtensions
{
    public static void ConfigureAudit<T>(this EntityTypeBuilder<T> builder)
        where T : BaseAuditEntity
    {
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.UpdatedBy);
    }
}
