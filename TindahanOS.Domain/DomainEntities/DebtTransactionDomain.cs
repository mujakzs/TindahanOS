using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class DebtTransactionDomain
{
    public Guid Id { get; set; }

    public Guid DebtAccountId { get; set; }

    public DebtTransactionType Type { get; set; } = DebtTransactionType.Charge;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public decimal GetBalanceEffect()
    {
        if (Amount <= 0)
        {
            throw new InvalidOperationException("Transaction amount must be greater than zero.");
        }

        return Type switch
        {
            DebtTransactionType.Charge => Amount,
            DebtTransactionType.Repayment => -Amount,
            DebtTransactionType.AdjustmentIncrease => Amount,
            DebtTransactionType.AdjustmentDecrease => -Amount,

            _ => throw new InvalidOperationException($"Invalid debt transaction type: {Type}")
        };
    }
}