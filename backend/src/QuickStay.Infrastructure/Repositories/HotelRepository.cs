using QuickStay.Domain.Entities;
using QuickStay.Domain.Interfaces;
using QuickStay.Infrastructure.Persistence;

namespace QuickStay.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly QuickStayDbContext _dbContext;

    public HotelRepository(QuickStayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Hotel?> GetHotelByIdAsync(Guid hotelId)
    {
        return await _dbContext.Hotels.FindAsync(hotelId);
    }

}
