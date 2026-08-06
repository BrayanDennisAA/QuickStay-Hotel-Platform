namespace QuickStay.Api.Shared.Domain;

public abstract class AuditableEntityBase<TId> : EntityBase<TId>
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}