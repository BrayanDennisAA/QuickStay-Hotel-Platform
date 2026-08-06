using QuickStay.Api.Modules.Availability.Application.DTOs;

namespace QuickStay.Api.Modules.Availability.Application.Interfaces;
public interface IAvailabilityService
{
    Task<IReadOnlyList<HotelAvailabilityDto>> CheckAvailabilityAsync(
        Guid hotelId,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default);

    Task<IReadOnlyDictionary<Guid, bool>> CheckAvailabilityByHotelsAsync(
        IReadOnlyList<Guid> hotelIds,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default);
}