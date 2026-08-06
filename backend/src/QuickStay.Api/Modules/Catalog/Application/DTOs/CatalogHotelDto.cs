namespace QuickStay.Api.Modules.Catalog.Application.DTOs;

public sealed record CatalogHotelDto(
    Guid HotelId,
    string Name,
    string City,
    string Country
);