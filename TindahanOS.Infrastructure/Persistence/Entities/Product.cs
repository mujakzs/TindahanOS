
namespace TindahanOS.Infrastructure.Persistence.Entities;

public class Product : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string? SKU { get; set; }

    public string? Description { get; set; }

    public int Unit { get; set; } = 1;

    public decimal SellingPrice { get; set; }

    public decimal? CostPrice { get; set; }

    public int Status { get; set; } = 1;
}