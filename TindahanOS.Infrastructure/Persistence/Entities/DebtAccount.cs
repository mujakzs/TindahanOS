namespace TindahanOS.Infrastructure.Persistence.Entities;

public class DebtAccount : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; } = null!;

    public int Status { get; set; } = 1;

    public string? Notes { get; set; }
}