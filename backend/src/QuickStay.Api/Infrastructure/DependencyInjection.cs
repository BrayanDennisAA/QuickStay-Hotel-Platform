using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Infrastructure.Persistence;

namespace QuickStay.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<QuickStayDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }

}
