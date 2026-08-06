using QuickStay.Api.Modules.Search.Application.Interfaces;
using QuickStay.Api.Modules.Search.Application.Services;

namespace QuickStay.Api.Modules.Search;

public static class DependencyInjection
{
    public static IServiceCollection AddSearchModule(this IServiceCollection services)
    {
        services.AddScoped<ISearchService, SearchService>();
        return services;
    }
}