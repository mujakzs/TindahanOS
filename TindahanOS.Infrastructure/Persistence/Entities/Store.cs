

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class Store : BaseAuditEntity
{
    public string Name { get; set; } = string.Empty;

    public string? BusinessName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int Status { get; set; } = 1;

    public ICollection<StoreMembership> StoreMemberships { get; set; } = new List<StoreMembership>();

    public ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public ICollection<Product> Products { get; set; } = new List<Product>();

    public ICollection<GCashTransaction> GCashTransactions { get; set; } = new List<GCashTransaction>();

    public ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

}