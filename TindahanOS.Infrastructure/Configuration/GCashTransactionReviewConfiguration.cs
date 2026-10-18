using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Configuration;

public class GCashTransactionReviewConfiguration
    : IEntityTypeConfiguration<GCashTransactionReview>
{
    public void Configure(
        EntityTypeBuilder<GCashTransactionReview> builder)
    {
        builder.ToTable("GCashTransactionReviews", table =>
        {
            table.HasCheckConstraint(
                "CK_GCashTransactionReviews_Result_Valid",
                "[ReviewResult] IN (1, 2, 3, 4)");
        });

        builder.HasKey(x => x.Id);

        // Transaction relationship
        builder.Property(x => x.GCashTransactionId)
            .IsRequired();

        builder.HasOne(x => x.GCashTransaction)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.GCashTransactionId)
            .OnDelete(DeleteBehavior.NoAction);

        // Reviewer relationship
        builder.Property(x => x.ReviewerUserId)
            .IsRequired();

        builder.HasOne(x => x.ReviewerUser)
            .WithMany()
            .HasForeignKey(x => x.ReviewerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Review result
        builder.Property(x => x.ReviewResult)
            .IsRequired();

        // Reason or evidence summary
        builder.Property(x => x.Reason)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.ReviewedAt)
            .IsRequired();

        // Query indexes
        builder.HasIndex(x => new
        {
            x.GCashTransactionId,
            x.ReviewedAt
        });

        builder.HasIndex(x => x.ReviewerUserId);

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