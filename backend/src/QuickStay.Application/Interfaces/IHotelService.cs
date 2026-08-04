using QuickStay.Application.DTOs.Responses;

namespace QuickStay.Application.Interfaces;

public interface IHotelService
{

    Task<HotelResponse> GetHotelByIdAsync(Guid hotelId);

}
