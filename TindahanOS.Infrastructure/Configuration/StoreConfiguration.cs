using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Configuration;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Stores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.BusinessName)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(x => x.Address)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(x => x.Status)
            .HasDefaultValue(1)
            .IsRequired();

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