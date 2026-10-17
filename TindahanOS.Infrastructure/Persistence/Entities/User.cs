
using TindahanOS.Infrastructure.Persistence.Entities.Stores;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class User : BaseAuditEntity
{
    public string Username { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    // Store the enum's numeric value in the database.
    public int Status { get; set; } = 1;

    public ICollection<StoreMembership> StoreMemberships { get; set; } = new List<StoreMembership>();
}
