using QuickStay.Application.DTOs.Responses;
using QuickStay.Application.Interfaces;
using QuickStay.Domain.Interfaces;

namespace QuickStay.Application.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<HotelResponse> GetHotelByIdAsync(Guid hotelId)
    {
        var hotel =  await _hotelRepository.GetHotelByIdAsync(hotelId);

        if (hotel == null)
        {
            throw new KeyNotFoundException("Hotel not found");
        }

        return new HotelResponse(
            hotel.Id,
            hotel.Name,
            hotel.City,
            hotel.Country
        );
    }

}
