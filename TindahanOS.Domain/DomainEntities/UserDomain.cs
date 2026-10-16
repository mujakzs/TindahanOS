

using TindahanOS.Infrastructure.Persistence.Entities.Users;

namespace TindahanOS.Domain.DomainEntities;

public class UserDomain
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public UserStatus Status { get; set; } = UserStatus.Active;

    public void Disable()
    {
        Status = UserStatus.Disabled;
    }

    public void Activate()
    {
        Status = UserStatus.Active;
    }
}
