using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class GCashTransactionReviewMapping
{
    public static GCashTransactionReviewDomain ToDomain(
        this GCashTransactionReview review)
    {
        return new GCashTransactionReviewDomain
        {
            Id = review.Id,
            GCashTransactionId = review.GCashTransactionId,
            ReviewerUserId = review.ReviewerUserId,

            ReviewResult = Enum.IsDefined(
                typeof(GCashReviewResult),
                review.ReviewResult)
                ? (GCashReviewResult)review.ReviewResult
                : throw new InvalidOperationException(
                    $"Invalid GCash review result: {review.ReviewResult}"),

            Reason = review.Reason,
            ReviewedAt = review.ReviewedAt
        };
    }

    public static GCashTransactionReview ToEntity(
        this GCashTransactionReviewDomain domain)
    {
        return new GCashTransactionReview
        {
            Id = domain.Id,
            GCashTransactionId = domain.GCashTransactionId,
            ReviewerUserId = domain.ReviewerUserId,
            ReviewResult = (int)domain.ReviewResult,
            Reason = domain.Reason,
            ReviewedAt = domain.ReviewedAt
        };
    }
}