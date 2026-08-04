using Microsoft.Extensions.DependencyInjection;
using QuickStay.Application.Interfaces;
using QuickStay.Application.Services;

namespace QuickStay.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();

        return services;
    }
}
