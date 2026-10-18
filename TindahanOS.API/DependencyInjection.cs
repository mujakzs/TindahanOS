using Microsoft.EntityFrameworkCore;
using TindahanOS.Infrastructure.Persistence.Entities;

namespace TindahanOS.API;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
