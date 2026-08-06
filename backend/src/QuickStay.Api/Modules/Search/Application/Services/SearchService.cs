using QuickStay.Api.Modules.Availability.Application.Interfaces;
using QuickStay.Api.Modules.Catalog.Application.Interfaces;
using QuickStay.Api.Modules.Search.Application.DTOs;
using QuickStay.Api.Modules.Search.Application.Interfaces;

namespace QuickStay.Api.Modules.Search.Application.Services;

public class SearchService : ISearchService
{
    private readonly ICatalogService _catalogService;
    private readonly IAvailabilityService _availabilityService;

    public SearchService(ICatalogService catalogService, IAvailabilityService availabilityService)
    {
        _catalogService = catalogService;
        _availabilityService = availabilityService;
    }

    public async Task<IReadOnlyList<SearchHotelItemDto>> SearchHotelsAsync(
        string city,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default)
    {
        var hotels = await _catalogService.GetActiveHotelsByCityAsync(city, ct);
        if (hotels.Count == 0) return [];

        var availabilityMap = await _availabilityService.CheckAvailabilityByHotelsAsync(
            hotels.Select(h => h.HotelId).ToList(),
            checkIn,
            checkOut,
            ct);

        return hotels
            .Select(h => new SearchHotelItemDto(
                h.HotelId,
                h.Name,
                h.City,
                h.Country,
                availabilityMap.TryGetValue(h.HotelId, out var available) && available))
            .ToList();
    }
}