using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class StoreMembershipConfiguration
    : IEntityTypeConfiguration<StoreMembership>
{
    public void Configure(EntityTypeBuilder<StoreMembership> builder)
    {
        builder.ToTable("StoreMemberships");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.Property(x => x.Role)
            .HasDefaultValue(3)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

        // Constrain allowed role and status values
        builder.HasCheckConstraint("CK_StoreMemberships_Role_Valid", "[Role] IN (1,2,3)");
        builder.HasCheckConstraint("CK_StoreMemberships_Status_Valid", "[Status] IN (1,2)");

        builder.HasIndex(x => new { x.StoreId, x.UserId })
            .IsUnique();

        builder.HasOne(x => x.User)
            .WithMany(x => x.StoreMemberships)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Store)
            .WithMany(x => x.StoreMemberships)
            .HasForeignKey(x => x.StoreId)
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