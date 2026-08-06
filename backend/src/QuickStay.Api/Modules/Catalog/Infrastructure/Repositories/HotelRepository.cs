using QuickStay.Api.Modules.Catalog.Domain.Entities;
using QuickStay.Api.Modules.Catalog.Domain.Interfaces;
using QuickStay.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace QuickStay.Api.Modules.Catalog.Infrastructure.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly QuickStayDbContext _db;

    public HotelRepository(QuickStayDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Hotel>> GetActiveByCityAsync(string city, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(city))
            return [];

        var normalized = city.Trim().ToLower();

        return await _db.Hotels
            .AsNoTracking()
            .Where(h => h.IsActive && h.City.ToLower() == normalized)
            .OrderBy(h => h.Name)
            .ToListAsync(ct);
    }
}