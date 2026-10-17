namespace TindahanOS.Domain.DomainEntities;

public class DebtTransactionItemDomain
{
    public Guid Id { get; set; }

    public Guid DebtTransactionId { get; set; }

    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }

    public void CalculateLineTotal()
    {
        if (Quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(Quantity),
                "Quantity must be greater than zero.");
        }

        if (UnitPrice < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(UnitPrice),
                "Unit price cannot be negative.");
        }

        LineTotal = decimal.Round(
            Quantity * UnitPrice,
            2,
            MidpointRounding.AwayFromZero);
    }
}