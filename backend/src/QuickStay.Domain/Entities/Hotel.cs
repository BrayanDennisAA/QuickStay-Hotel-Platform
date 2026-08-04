using QuickStay.Domain.Common;

namespace QuickStay.Domain.Entities;

public class Hotel : BaseEntity<Guid>
{
    public string Name { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    public bool IsActive { get; private set; } = true;

    private Hotel() { }


}
