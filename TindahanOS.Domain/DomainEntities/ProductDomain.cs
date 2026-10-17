using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class ProductDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? SKU { get; set; }

    public string? Description { get; set; }

    public ProductUnit Unit { get; set; } = ProductUnit.Piece;

    public decimal SellingPrice { get; set; }

    public decimal? CostPrice { get; set; }

    public ProductStatus Status { get; set; } = ProductStatus.Active;

    public void UpdateSellingPrice(decimal sellingPrice)
    {
        if (sellingPrice < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(sellingPrice),
                "Selling price cannot be negative.");
        }

        SellingPrice = sellingPrice;
    }

    public void UpdateCostPrice(decimal? costPrice)
    {
        if (costPrice < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(costPrice),
                "Cost price cannot be negative.");
        }

        CostPrice = costPrice;
    }

    public void Deactivate()
    {
        Status = ProductStatus.Inactive;
    }

    public void Activate()
    {
        Status = ProductStatus.Active;
    }
}