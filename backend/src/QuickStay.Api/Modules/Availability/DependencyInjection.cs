using QuickStay.Api.Modules.Availability.Application.Interfaces;
using QuickStay.Api.Modules.Availability.Application.Services;
using QuickStay.Api.Modules.Availability.Domain.Interfaces;
using QuickStay.Api.Modules.Availability.Infrastructure.Repositories;

namespace QuickStay.Api.Modules.Availability;

public static class DependencyInjection
{
    public static IServiceCollection AddAvailabilityModule(this IServiceCollection services)
    {
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IAvailabilityService, AvailabilityService>();
        return services;
    }
}