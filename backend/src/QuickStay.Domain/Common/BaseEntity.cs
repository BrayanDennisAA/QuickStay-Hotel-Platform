using System;

namespace QuickStay.Domain.Common;

public abstract class BaseEntity<TId>
{
    public TId Id { get; } = default!;
}
