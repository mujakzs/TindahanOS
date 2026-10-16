using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class StoreDomain
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? BusinessName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public StoreStatus Status { get; set; } = StoreStatus.Active;

    public void Suspend()
    {
        Status = StoreStatus.Suspended;
    }

    public void Activate()
    {
        Status = StoreStatus.Active;
    }

    public void Close()
    {
        Status = StoreStatus.Closed;
    }
}