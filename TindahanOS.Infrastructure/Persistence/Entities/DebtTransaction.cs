namespace TindahanOS.Infrastructure.Persistence.Entities.Debts;

public class DebtTransaction : BaseAuditEntity
{
    public Guid DebtAccountId { get; set; }

    public DebtAccount DebtAccount { get; set; } = null!;

    public int Type { get; set; } = 1;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public ICollection<DebtTransactionItem> Items { get; set; } = new List<DebtTransactionItem>();
}