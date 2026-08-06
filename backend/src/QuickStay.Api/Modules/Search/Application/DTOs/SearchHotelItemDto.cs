namespace QuickStay.Api.Modules.Search.Application.DTOs;
public sealed record SearchHotelItemDto(
    Guid HotelId,
    string Name,
    string City,
    string Country,
    bool IsAvailable
);