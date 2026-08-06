namespace QuickStay.Api.Modules.Payments.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer,
        Cash
    }
}