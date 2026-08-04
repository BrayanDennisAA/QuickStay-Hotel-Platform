using QuickStay.Domain.Entities;

namespace QuickStay.Domain.Interfaces;

public interface IHotelRepository
{
    Task<Hotel?> GetHotelByIdAsync(Guid hotelId);
    Task<IEnumerable<Hotel>> SearchHotelsAsync(string? city);

}
