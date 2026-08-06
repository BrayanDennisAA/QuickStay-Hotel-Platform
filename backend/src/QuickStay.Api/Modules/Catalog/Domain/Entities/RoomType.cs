using QuickStay.Api.Shared.Domain;

namespace QuickStay.Api.Modules.Catalog.Domain.Entities;

public class RoomType: EntityBase<Guid>
{
    public Guid HotelId { get; set; }
    public string Name { get; set; } = default!;
    public int Capacity { get; set; }
    public decimal BasePrice { get; set; }

    public Hotel Hotel { get; set; } = default!;
}