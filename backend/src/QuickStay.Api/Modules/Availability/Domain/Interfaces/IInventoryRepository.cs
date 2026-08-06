using QuickStay.Api.Modules.Availability.Domain.Entities;

namespace QuickStay.Api.Modules.Availability.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<IReadOnlyList<Inventory>> GetByHotelAndDateRangeAsync(
        Guid hotelId,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default);

    Task<IReadOnlyList<Inventory>> GetByHotelsAndDateRangeAsync(
        IReadOnlyList<Guid> hotelIds,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default);
}