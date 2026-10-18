using TindahanOS.Domain.Enums;

namespace TindahanOS.Domain.DomainEntities;

public class AuditLogDomain
{
    public Guid Id { get; set; }

    public Guid? StoreId { get; set; }

    public Guid? UserId { get; set; }

    public AuditActionType ActionType { get; set; }

    public string EntityName { get; set; } = string.Empty;

    public string? EntityId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string? IpAddress { get; set; }

    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
}