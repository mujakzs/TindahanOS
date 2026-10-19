using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.Enums;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Mappings;

public class UserMapping : IEntityMapper<UserDomain, User>
{
    // ToDomain() converts the database entity into a business entity.
    public UserDomain ToDomain(User entity)
    {
        return new UserDomain
        {
            Id = entity.Id,
            Username = entity.Username,
            FullName = entity.FullName,
            Email = entity.Email,
            PasswordHash = entity.PasswordHash,
            PhoneNumber = entity.PhoneNumber,
            Status = Enum.IsDefined(typeof(UserStatus), entity.Status)
                ? (UserStatus)entity.Status
                : throw new InvalidOperationException(
                    $"Invalid user status value: {entity.Status}")
        };
    }

    // ToEntity() converts the business entity into a persistence entity.
    public User ToEntity(UserDomain domain)
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

    public void UpdateEntity(UserDomain domain, User entity)
    {
        entity.Username = domain.Username;
        entity.FullName = domain.FullName;
        entity.Email = domain.Email;
        entity.PasswordHash = domain.PasswordHash;
        entity.PhoneNumber = domain.PhoneNumber;
        entity.Status = (int)domain.Status;
    }
}