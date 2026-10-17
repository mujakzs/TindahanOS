using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Persistence.Entities.Customers;

public class Customer : BaseAuditEntity
{
    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;

    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; } = 1;
}