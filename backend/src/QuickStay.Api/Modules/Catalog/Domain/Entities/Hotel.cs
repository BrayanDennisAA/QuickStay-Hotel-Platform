using QuickStay.Api.Shared.Domain;

namespace QuickStay.Api.Modules.Catalog.Domain.Entities;

public class Hotel : AuditableEntityBase<Guid>
{
    public string Name { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string Country { get; private set; } = default!;
    public bool IsActive { get; private set; } = true;

    public List<RoomType> RoomTypes { get; private set; } = new List<RoomType>();

    private Hotel() { }

    public Hotel(Guid guid, string name, string city, string country, bool isActive = true)
    {
        Id = guid;
        Name = name;
        City = city;
        Country = country;
        IsActive = isActive;
    }


}