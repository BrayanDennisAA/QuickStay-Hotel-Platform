using QuickStay.Api.Modules.Catalog.Application.DTOs;

namespace QuickStay.Api.Modules.Catalog.Application.Interfaces;

public interface ICatalogService
{
    Task<IReadOnlyList<CatalogHotelDto>> GetActiveHotelsByCityAsync(string city, CancellationToken ct = default);
}