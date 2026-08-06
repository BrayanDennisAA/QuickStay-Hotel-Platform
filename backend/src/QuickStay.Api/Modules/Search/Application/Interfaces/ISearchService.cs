using QuickStay.Api.Modules.Search.Application.DTOs;

namespace QuickStay.Api.Modules.Search.Application.Interfaces;
public interface ISearchService
{
    Task<IReadOnlyList<SearchHotelItemDto>> SearchHotelsAsync(
        string city,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default);
}