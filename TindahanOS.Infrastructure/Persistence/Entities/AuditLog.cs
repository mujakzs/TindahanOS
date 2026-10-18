namespace TindahanOS.Infrastructure.Persistence.Entities;

public class AuditLog
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid? StoreId { get; set; }

    public Guid? UserId { get; set; }

    public int ActionType { get; set; }

    public string EntityName { get; set; } = string.Empty;

    public string? EntityId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string? IpAddress { get; set; }

    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}