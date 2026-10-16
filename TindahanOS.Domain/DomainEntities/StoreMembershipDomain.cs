using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class StoreMembershipDomain
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public Guid StoreId { get; set; }

    public StoreRole Role { get; set; } = StoreRole.Staff;

    public StoreMembershipStatus Status { get; set; }
        = StoreMembershipStatus.Active;

    public void ChangeRole(StoreRole role)
    {
        Role = role;
    }

    public void Suspend()
    {
        Status = StoreMembershipStatus.Suspended;
    }

    public void Activate()
    {
        Status = StoreMembershipStatus.Active;
    }
}