
using TindahanOS.Domain.DomainEntities;

namespace TindahanOS.Domain.RepositoryInterface;

public interface IUserRepository : IGenericRepository<UserDomain>
{
    Task<UserDomain?> GetByUsernameAsync(string username);
}
