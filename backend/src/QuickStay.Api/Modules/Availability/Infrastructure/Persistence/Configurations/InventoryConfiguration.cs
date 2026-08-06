using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickStay.Api.Modules.Availability.Domain.Entities;

public class InvetoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("availability_inventory");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.HotelId, x.RoomTypeId, x.Date }).IsUnique();
    }
}
