using System;

namespace QuickStay.Api.Shared.Domain;

public abstract class EntityBase<TId>
{
    public TId Id { get; protected set;} = default!;

}
