namespace TindahanOS.Infrastructure.Persistence.Entities;

public class GCashTransaction : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public int TransactionType { get; set; } = 1;

    public string? CustomerName { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string? ReferenceNumber { get; set; }

    public int Status { get; set; } = 1;

    public string? Notes { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public ICollection<GCashTransactionReview> Reviews { get; set; } = new List<GCashTransactionReview>();

}