using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class GCashTransactionReviewDomain
{
    public Guid Id { get; set; }

    public Guid GCashTransactionId { get; set; }

    public Guid ReviewerUserId { get; set; }

    public GCashReviewResult ReviewResult { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime ReviewedAt { get; set; } = DateTime.UtcNow;
}