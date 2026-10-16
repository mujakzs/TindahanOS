using Microsoft.EntityFrameworkCore;
using TindahanOS.Infrastructure.Persistence.Entities.Stores;
using TindahanOS.Infrastructure.Persistence.Entities.Users;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Store> Stores => Set<Store>();



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}
