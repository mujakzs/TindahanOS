using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class DebtAccountMapping
{
    public static DebtAccountDomain ToDomain(
        this DebtAccount account)
    {
        return new DebtAccountDomain
        {
            Id = account.Id,
            StoreId = account.StoreId,
            CustomerId = account.CustomerId,
            Notes = account.Notes,

            Status = Enum.IsDefined(
                typeof(DebtAccountStatus),
                account.Status)
                ? (DebtAccountStatus)account.Status
                : throw new InvalidOperationException(
                    $"Invalid debt account status: {account.Status}")
        };
    }

    public static DebtAccount ToEntity(
        this DebtAccountDomain domain)
    {
        return new DebtAccount
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            CustomerId = domain.CustomerId,
            Notes = domain.Notes,
            Status = (int)domain.Status
        };
    }
}