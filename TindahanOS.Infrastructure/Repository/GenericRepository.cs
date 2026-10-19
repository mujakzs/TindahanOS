using Microsoft.EntityFrameworkCore;
using TindahanOS.Domain.RepositoryInterface;
using TindahanOS.Infrastructure.Mappings;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.Infrastructure.Repository
{
    public class GenericRepository<TDomain, TEntity> : IGenericRepository<TDomain>
        where TDomain : class
        where TEntity : BaseAuditEntity
    {
        protected readonly ApplicationDBContext _db;
        protected readonly DbSet<TEntity> _set;
        protected readonly IEntityMapper<TDomain, TEntity> _mapper;

        public GenericRepository(ApplicationDBContext db, IEntityMapper<TDomain, TEntity> mapper)
        {
            _db = db;
            _set = db.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<TDomain?> GetByIdAsync(object id)
        {
            var entity = await _set.FindAsync(new[] { id });
            return entity is null ? null : _mapper.ToDomain(entity);
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            var entities = await _set.AsNoTracking().ToListAsync();
            return entities.Select(_mapper.ToDomain).ToList();
        }

        public async Task AddAsync(TDomain domain)
        {
            var entity = _mapper.ToEntity(domain);
            await _set.AddAsync(entity);
        }

        public async Task UpdateAsync(TDomain domain)
        {
            var incomingId = _mapper.ToEntity(domain).Id;

            // Reuse the tracked instance if one exists, otherwise load it
            var existing = await _set.FindAsync(new object[] { incomingId })
                ?? throw new KeyNotFoundException(
                    $"{typeof(TEntity).Name} with id '{incomingId}' was not found.");

            _mapper.UpdateEntity(domain, existing);
        }

        public Task DetachAsync(object entityId)
        {
            var entry = _db.ChangeTracker.Entries<TEntity>()
                .FirstOrDefault(e => e.Entity.Id.Equals(entityId));

            if (entry is not null)
                entry.State = EntityState.Detached;

            return Task.CompletedTask;
        }

        public Task<int> CommitAsync() => _db.SaveChangesAsync();
    }
}
