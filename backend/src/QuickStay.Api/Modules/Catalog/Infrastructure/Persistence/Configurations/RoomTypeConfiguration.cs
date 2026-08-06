using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickStay.Api.Modules.Catalog.Domain.Entities;

namespace QuickStay.Api.Modules.Catalog.Infrastructure.Persistence.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("catalog_room_types");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.BasePrice).HasColumnType("numeric(12,2)");
        builder.HasOne(x => x.Hotel).WithMany(h => h.RoomTypes).HasForeignKey(x => x.HotelId);
    }
}