using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Mappings;

public static class StoreMembershipMapping
{
    public static StoreMembershipDomain ToDomain(
        this StoreMembership membership)
    {
        return new StoreMembershipDomain
        {
            Id = membership.Id,
            UserId = membership.UserId,
            StoreId = membership.StoreId,

            Role = Enum.IsDefined(typeof(StoreRole), membership.Role)
                ? (StoreRole)membership.Role
                : throw new InvalidOperationException(
                    $"Invalid store role: {membership.Role}"),

            Status = Enum.IsDefined(
                typeof(StoreMembershipStatus), membership.Status)
                ? (StoreMembershipStatus)membership.Status
                : throw new InvalidOperationException(
                    $"Invalid membership status: {membership.Status}")
        };
    }

    public static StoreMembership ToEntity(
        this StoreMembershipDomain domain)
    {
        return new StoreMembership
        {
            Id = domain.Id,
            UserId = domain.UserId,
            StoreId = domain.StoreId,
            Role = (int)domain.Role,
            Status = (int)domain.Status
        };
    }
}