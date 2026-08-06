using QuickStay.Api.Shared.Domain;

namespace QuickStay.Api.Modules.Availability.Domain.Entities
{
    public class Inventory : EntityBase<Guid>
    {
        public Guid HotelId { get; private set; }
        public Guid RoomTypeId { get; private set; }
        public DateOnly Date { get; private set; }
        public int TotalRooms { get; private set; }
        public int ReservedRooms { get; private set; }

        public int AvailableRooms => TotalRooms - ReservedRooms;
    }
}