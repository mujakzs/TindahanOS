using TindahanOS.Infrastructure.Persistence.Entities.Products;

namespace TindahanOS.Infrastructure.Persistence.Entities.Debts;

public class DebtTransactionItem : BaseAuditEntity
{
    public Guid DebtTransactionId { get; set; }

    public DebtTransaction DebtTransaction { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}