using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities.Users;

namespace TindahanOS.Infrastructure.Mappings;

public static class UserMapping
{
    // ToDomain() converts the database entity into a business entity.
    public static UserDomain ToDomain(this User user)
    {
        return new UserDomain
        {
            Id = user.Id,
            Username = user.Username,
            FullName = user.FullName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            PhoneNumber = user.PhoneNumber,
            Status = Enum.IsDefined(typeof(UserStatus), user.Status)
                ? (UserStatus)user.Status
                : throw new InvalidOperationException(
                    $"Invalid user status value: {user.Status}")
        };
    }

    // ToEntity() converts the business entity into a persistence entity.
    public static User ToEntity(this UserDomain domain)
    {
        return new User
        {
            Id = domain.Id,
            Username = domain.Username,
            FullName = domain.FullName,
            Email = domain.Email,
            PasswordHash = domain.PasswordHash,
            PhoneNumber = domain.PhoneNumber,
            Status = (int)domain.Status
        };
    }
}