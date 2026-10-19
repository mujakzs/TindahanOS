namespace TindahanOS.Infrastructure.Mappings;

public interface IEntityMapper<TDomain, TEntity>
{
    TDomain ToDomain(TEntity entity);
    TEntity ToEntity(TDomain domain);

    // Copies domain values onto an already-tracked entity
    void UpdateEntity(TDomain domain, TEntity entity);
}