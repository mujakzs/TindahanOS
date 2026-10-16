using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Mappings;

public static class StoreMapping
{
    public static StoreDomain ToDomain(this Store store)
    {
        return new StoreDomain
        {
            Id = store.Id,
            Name = store.Name,
            BusinessName = store.BusinessName,
            PhoneNumber = store.PhoneNumber,
            Address = store.Address,
            Status = Enum.IsDefined(typeof(StoreStatus), store.Status)
                ? (StoreStatus)store.Status
                : throw new InvalidOperationException(
                    $"Invalid store status value: {store.Status}")
        };
    }

    public static Store ToEntity(this StoreDomain domain)
    {
        return new Store
        {
            Id = domain.Id,
            Name = domain.Name,
            BusinessName = domain.BusinessName,
            PhoneNumber = domain.PhoneNumber,
            Address = domain.Address,
            Status = (int)domain.Status
        };
    }
}