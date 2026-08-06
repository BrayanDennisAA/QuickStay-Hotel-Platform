using QuickStay.Api.Modules.Catalog.Application.DTOs;
using QuickStay.Api.Modules.Catalog.Application.Interfaces;
using QuickStay.Api.Modules.Catalog.Domain.Interfaces;

namespace QuickStay.Api.Modules.Catalog.Application.Services;
public class CatalogService : ICatalogService
{
    private readonly IHotelRepository _hotelRepository;

    public CatalogService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<IReadOnlyList<CatalogHotelDto>> GetActiveHotelsByCityAsync(string city, CancellationToken ct = default)
    {
        var hotels = await _hotelRepository.GetActiveByCityAsync(city, ct);

        return hotels
            .Select(h => new CatalogHotelDto(h.Id, h.Name, h.City, h.Country))
            .ToList();
    }
}