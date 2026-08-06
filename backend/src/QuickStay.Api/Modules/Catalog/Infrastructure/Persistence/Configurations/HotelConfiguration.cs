using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Modules.Catalog.Domain.Entities;

namespace QuickStay.Api.Modules.Catalog.Infrastructure.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("catalog_hotels");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).IsRequired().HasMaxLength(100);
        builder.Property(h => h.City).IsRequired().HasMaxLength(50);
        builder.Property(h => h.Country).IsRequired().HasMaxLength(50);
        builder.Property(h => h.IsActive).IsRequired();
        builder.HasIndex(x => new { x.City, x.IsActive });
    }
}
