using TindahanOS.Infrastructure.Persistence.Entities.Users;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class StoreMembership : BaseAuditEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public int Role { get; set; } = 3;

    public int Status { get; set; } = 1;
}