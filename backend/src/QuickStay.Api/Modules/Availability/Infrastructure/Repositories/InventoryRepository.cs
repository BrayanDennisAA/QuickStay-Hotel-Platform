using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Infrastructure.Persistence;
using QuickStay.Api.Modules.Availability.Domain.Entities;
using QuickStay.Api.Modules.Availability.Domain.Interfaces;

namespace QuickStay.Api.Modules.Availability.Infrastructure.Repositories;
public class InventoryRepository : IInventoryRepository
{
    private readonly QuickStayDbContext _db;

    public InventoryRepository(QuickStayDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Inventory>> GetByHotelAndDateRangeAsync(
        Guid hotelId,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default)
    {
        return await _db.Inventories
            .AsNoTracking()
            .Where(i => i.HotelId == hotelId && i.Date >= checkIn && i.Date < checkOut)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<Inventory>> GetByHotelsAndDateRangeAsync(
        IReadOnlyList<Guid> hotelIds,
        DateOnly checkIn,
        DateOnly checkOut,
        CancellationToken ct = default)
    {
        if (hotelIds.Count == 0) return [];

        return await _db.Inventories
            .AsNoTracking()
            .Where(i => hotelIds.Contains(i.HotelId) && i.Date >= checkIn && i.Date < checkOut)
            .ToListAsync(ct);
    }
}