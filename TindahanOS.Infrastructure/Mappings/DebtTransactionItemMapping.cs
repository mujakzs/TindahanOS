using TindahanOS.Domain.DomainEntities;
using TindahanOS.Infrastructure.Persistence.Entities.Debts;

namespace TindahanOS.Infrastructure.Mappings;

public static class DebtTransactionItemMapping
{
    public static DebtTransactionItemDomain ToDomain(
        this DebtTransactionItem item)
    {
        return new DebtTransactionItemDomain
        {
            Id = item.Id,
            DebtTransactionId = item.DebtTransactionId,
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            LineTotal = item.LineTotal
        };
    }

    public static DebtTransactionItem ToEntity(
        this DebtTransactionItemDomain domain)
    {
        return new DebtTransactionItem
        {
            Id = domain.Id,
            DebtTransactionId = domain.DebtTransactionId,
            ProductId = domain.ProductId,
            Quantity = domain.Quantity,
            UnitPrice = domain.UnitPrice,
            LineTotal = domain.LineTotal
        };
    }
}