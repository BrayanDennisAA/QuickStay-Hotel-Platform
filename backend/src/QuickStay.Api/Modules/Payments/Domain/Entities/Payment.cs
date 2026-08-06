using QuickStay.Api.Modules.Payments.Domain.Enums;
using QuickStay.Api.Shared.Domain;
using QuickStay.Api.Shared.Domain.ValueObjects;

namespace QuickStay.Api.Modules.Payments.Domain.Entities
{
    public class Payment : EntityBase<Guid>
    {
        public Guid ReservationId { get; private set; }
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; } = default!;
        public PaymentMethod Method { get; private set; } = PaymentMethod.CreditCard;
        public PaymentStatus Status { get; private set; } = PaymentStatus.Pending;
        public string? ProviderReference { get; private set; }
    }
}