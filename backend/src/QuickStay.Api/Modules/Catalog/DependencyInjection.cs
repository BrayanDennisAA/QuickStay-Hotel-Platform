using QuickStay.Api.Modules.Catalog.Application.Interfaces;
using QuickStay.Api.Modules.Catalog.Application.Services;
using QuickStay.Api.Modules.Catalog.Domain.Interfaces;
using QuickStay.Api.Modules.Catalog.Infrastructure.Repositories;

namespace QuickStay.Api.Modules.Catalog;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        return services;
    }
}