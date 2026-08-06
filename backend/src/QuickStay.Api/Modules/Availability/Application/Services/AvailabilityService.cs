using QuickStay.Api.Modules.Availability.Application.DTOs;
using QuickStay.Api.Modules.Availability.Application.Interfaces;
using QuickStay.Api.Modules.Availability.Domain.Interfaces;

namespace QuickStay.Api.Modules.Availability.Application.Services;
public class AvailabilityService : IAvailabilityService
{
    private readonly IInventoryRepository _inventoryRepository;

    public AvailabilityService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IReadOnlyList<HotelAvailabilityDto>> CheckAvailabilityAsync(
        Guid hotelId,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default)
    {
        if (checkOut <= checkIn) return [];

        var inventory = await _inventoryRepository.GetByHotelAndDateRangeAsync(hotelId, checkIn, checkOut, ct);
        var isAvailable = inventory.Any(i => (i.TotalRooms - i.ReservedRooms) > 0);

        return [new HotelAvailabilityDto(hotelId, isAvailable)];
    }

    public async Task<IReadOnlyDictionary<Guid, bool>> CheckAvailabilityByHotelsAsync(
        IReadOnlyList<Guid> hotelIds,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default)
    {
        if (hotelIds.Count == 0 || checkOut <= checkIn)
            return new Dictionary<Guid, bool>();

        var rows = await _inventoryRepository.GetByHotelsAndDateRangeAsync(hotelIds, checkIn, checkOut, ct);

        var grouped = rows
            .GroupBy(r => r.HotelId)
            .ToDictionary(g => g.Key, g => g.Any(x => (x.TotalRooms - x.ReservedRooms) > 0));

        var result = hotelIds.Distinct().ToDictionary(id => id, _ => false);
        foreach (var kv in grouped) result[kv.Key] = kv.Value;

        return result;
    }
}