using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class ProductMapping
{
    public static ProductDomain ToDomain(this Product product)
    {
        return new ProductDomain
        {
            Id = product.Id,
            StoreId = product.StoreId,
            Name = product.Name,
            SKU = product.SKU,
            Description = product.Description,

            Unit = Enum.IsDefined(
                typeof(ProductUnit),
                product.Unit)
                ? (ProductUnit)product.Unit
                : throw new InvalidOperationException(
                    $"Invalid product unit value: {product.Unit}"),

            SellingPrice = product.SellingPrice,
            CostPrice = product.CostPrice,

            Status = Enum.IsDefined(
                typeof(ProductStatus),
                product.Status)
                ? (ProductStatus)product.Status
                : throw new InvalidOperationException(
                    $"Invalid product status value: {product.Status}")
        };
    }

    public static Product ToEntity(this ProductDomain domain)
    {
        return new Product
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            Name = domain.Name,
            SKU = domain.SKU,
            Description = domain.Description,
            Unit = (int)domain.Unit,
            SellingPrice = domain.SellingPrice,
            CostPrice = domain.CostPrice,
            Status = (int)domain.Status
        };
    }
}