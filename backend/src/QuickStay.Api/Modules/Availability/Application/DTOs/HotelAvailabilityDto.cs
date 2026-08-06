namespace QuickStay.Api.Modules.Availability.Application.DTOs;

public sealed record HotelAvailabilityDto(
    Guid HotelId,
    bool IsAvailable
);