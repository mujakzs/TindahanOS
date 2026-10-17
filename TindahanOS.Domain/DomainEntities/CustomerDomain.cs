using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class CustomerDomain
{
    public Guid Id { get; set; }

    public Guid StoreId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public CustomerStatus Status { get; set; } = CustomerStatus.Active;

    public void Deactivate()
    {
        Status = CustomerStatus.Inactive;
    }

    public void Activate()
    {
        Status = CustomerStatus.Active;
    }

    public void UpdateContactInformation(
        string? phoneNumber,
        string? address)
    {
        PhoneNumber = phoneNumber;
        Address = address;
    }
}