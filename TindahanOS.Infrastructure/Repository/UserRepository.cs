using Microsoft.EntityFrameworkCore;
using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.RepositoryInterface;
using TindahanOS.Infrastructure.Mappings;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Repository;

public class UserRepository : GenericRepository<UserDomain, User>, IUserRepository
{
    public UserRepository(ApplicationDBContext db, IEntityMapper<UserDomain, User> mapper)
        : base(db, mapper) { }

    public async Task<UserDomain?> GetByUsernameAsync(string username)
    {
        var entity = await _set.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
        return entity is null ? null : _mapper.ToDomain(entity);
    }
}
