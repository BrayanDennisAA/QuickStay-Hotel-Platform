using QuickStay.Api.Modules.Reservations.Domain.Enums;
using QuickStay.Api.Shared.Domain;

namespace QuickStay.Api.Modules.Reservations.Domain.Entities
{
    public class Reservation : EntityBase<Guid>
    {
        public Guid HotelId { get; set; }
        public Guid RoomTypeId { get; set; }
        public Guid UserId { get; set; }

        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int Guests { get; set; }
        public decimal TotalAmount { get; set; }

        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}