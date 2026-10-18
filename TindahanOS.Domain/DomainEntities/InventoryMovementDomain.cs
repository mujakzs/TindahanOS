using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class InventoryMovementDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public Guid ProductId { get; set; }

    public InventoryMovementType MovementType { get; set; } = InventoryMovementType.StockIn;

    public decimal Quantity { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? Notes { get; set; }

    public DateTime MovementDate { get; set; } = DateTime.UtcNow;

    public decimal GetStockEffect()
    {
        if (Quantity <= 0)
        {
            throw new InvalidOperationException("Movement quantity must be greater than zero.");
        }

        return MovementType switch
        {
            InventoryMovementType.StockIn => Quantity,
            InventoryMovementType.Sale => -Quantity,
            InventoryMovementType.CustomerReturn => Quantity,
            InventoryMovementType.Damaged => -Quantity,
            InventoryMovementType.AdjustmentIncrease => Quantity,
            InventoryMovementType.AdjustmentDecrease => -Quantity,

            _ => throw new InvalidOperationException($"Invalid inventory movement type: {MovementType}")
        };
    }
}