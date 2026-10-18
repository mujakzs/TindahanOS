namespace TindahanOS.Infrastructure.Persistence.Entities;

public class GCashTransactionReview : BaseAuditEntity
{
    public Guid GCashTransactionId { get; set; }

    public GCashTransaction GCashTransaction { get; set; } = null!;

    public Guid ReviewerUserId { get; set; }

    public User ReviewerUser { get; set; } = null!;

    public int ReviewResult { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime ReviewedAt { get; set; } = DateTime.UtcNow;
}