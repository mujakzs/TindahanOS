using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public static class AuditLogMapping
{
    public static AuditLogDomain ToDomain(this AuditLog auditLog)
    {
        return new AuditLogDomain
        {
            Id = auditLog.Id,
            StoreId = auditLog.StoreId,
            UserId = auditLog.UserId,

            ActionType = Enum.IsDefined(
                typeof(AuditActionType),
                auditLog.ActionType)
                ? (AuditActionType)auditLog.ActionType
                : throw new InvalidOperationException(
                    $"Invalid audit action type: {auditLog.ActionType}"),

            EntityName = auditLog.EntityName,
            EntityId = auditLog.EntityId,
            Description = auditLog.Description,
            IpAddress = auditLog.IpAddress,
            OccurredAt = auditLog.OccurredAt
        };
    }

    public static AuditLog ToEntity(this AuditLogDomain domain)
    {
        return new AuditLog
        {
            Id = domain.Id,
            StoreId = domain.StoreId,
            UserId = domain.UserId,
            ActionType = (int)domain.ActionType,
            EntityName = domain.EntityName,
            EntityId = domain.EntityId,
            Description = domain.Description,
            IpAddress = domain.IpAddress,
            OccurredAt = domain.OccurredAt
        };
    }
}