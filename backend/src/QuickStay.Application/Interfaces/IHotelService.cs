using QuickStay.Application.DTOs.Responses;

namespace QuickStay.Application.Interfaces;

public interface IHotelService
{

    Task<HotelResponse> GetHotelByIdAsync(Guid hotelId);
    Task<IEnumerable<HotelResponse>> SearchHotelsAsync(string? city);

}
