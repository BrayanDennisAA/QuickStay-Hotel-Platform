namespace QuickStay.Application.DTOs.Responses;

public record HotelResponse(
    Guid Id,
    string Name,
    string City,
    string Country
);