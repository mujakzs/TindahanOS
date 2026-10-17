using TindahanOS.Infrastructure.Persistence.Entities.Customers;
using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Persistence.Entities.Stores;

public class Store : BaseAuditEntity
{
    public string Name { get; set; } = string.Empty;

    public string? BusinessName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int Status { get; set; } = 1;

    public ICollection<StoreMembership> StoreMemberships { get; set; } = new List<StoreMembership>();

    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}