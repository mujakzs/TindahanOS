using Microsoft.EntityFrameworkCore;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<StoreMembership> StoreMemberships => Set<StoreMembership>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<DebtAccount> DebtAccounts => Set<DebtAccount>();
    public DbSet<DebtTransaction> DebtTransactions => Set<DebtTransaction>();
    public DbSet<DebtTransactionItem> DebtTransactionItem => Set<DebtTransactionItem>();
    public DbSet<GCashTransaction> GCashTransactions => Set<GCashTransaction>();
    public DbSet<GCashTransactionReview> GcashTransactionReviews => Set<GCashTransactionReview>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}
