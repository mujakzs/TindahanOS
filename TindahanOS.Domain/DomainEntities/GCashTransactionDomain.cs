using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class GCashTransactionDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public GCashTransactionType TransactionType { get; set; } = GCashTransactionType.CashIn;

    public string? CustomerName { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string? ReferenceNumber { get; set; }

    public GCashTransactionStatus Status { get; set; } = GCashTransactionStatus.Pending;

    public string? Notes { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public void Verify()
    {
        if (Status != GCashTransactionStatus.Pending)
        {
            throw new InvalidOperationException("Only pending transactions can be verified.");
        }

        Status = GCashTransactionStatus.Verified;
    }

    public void Reject(string reason)
    {
        if (Status != GCashTransactionStatus.Pending)
        {
            throw new InvalidOperationException("Only pending transactions can be rejected.");
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("A rejection reason is required.",nameof(reason));
        }

        Notes = reason;
        Status = GCashTransactionStatus.Rejected;
    }

    public void Cancel()
    {
        if (Status != GCashTransactionStatus.Pending)
        {
            throw new InvalidOperationException("Only pending transactions can be cancelled.");
        }

        Status = GCashTransactionStatus.Cancelled;
    }
}