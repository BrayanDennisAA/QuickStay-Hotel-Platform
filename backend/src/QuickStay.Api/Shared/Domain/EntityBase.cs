using System;

namespace QuickStay.Api.Shared.Domain;

public abstract class EntityBase<TId>
{
    public TId Id { get; protected set;} = default!;
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;

}
