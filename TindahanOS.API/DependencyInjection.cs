using Microsoft.EntityFrameworkCore;
using TindahanOS.Domain.DomainEntities;
using TindahanOS.Domain.RepositoryInterface;
using TindahanOS.Infrastructure.Mappings;
using TindahanOS.Infrastructure.Persistence.Entities;
using TindahanOS.Infrastructure.Repository;

namespace TindahanOS.API;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IEntityMapper<UserDomain, User>, UserMapping>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
