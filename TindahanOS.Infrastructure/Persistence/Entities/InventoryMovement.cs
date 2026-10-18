namespace TindahanOS.Infrastructure.Persistence.Entities;

public class InventoryMovement : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int MovementType { get; set; } = 1;

    public decimal Quantity { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public DateTime MovementDate { get; set; } = DateTime.UtcNow;
}