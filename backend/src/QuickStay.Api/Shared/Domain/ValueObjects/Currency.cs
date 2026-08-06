namespace QuickStay.Api.Shared.Domain.ValueObjects
{
    public record Currency
    {
        public string Code { get; init; } = default!;
        public string Symbol { get; init; } = default!;
        public string Name { get; init; } = default!;
    }
}