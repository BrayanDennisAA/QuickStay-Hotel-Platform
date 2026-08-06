using QuickStay.Api.Modules.Catalog.Domain.Entities;

namespace QuickStay.Api.Modules.Catalog.Domain.Interfaces
{
    public interface IHotelRepository
    {
        Task<IReadOnlyList<Hotel>> GetActiveByCityAsync(string city, CancellationToken ct = default);

    }
}