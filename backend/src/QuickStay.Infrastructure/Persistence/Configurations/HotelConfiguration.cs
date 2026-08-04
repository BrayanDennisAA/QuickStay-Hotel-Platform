using Microsoft.EntityFrameworkCore;
using QuickStay.Domain.Entities;

namespace QuickStay.Infrastructure.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("hotels");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).IsRequired().HasMaxLength(100);
        builder.Property(h => h.City).IsRequired().HasMaxLength(50);
        builder.Property(h => h.Country).IsRequired().HasMaxLength(50);
        builder.Property(h => h.IsActive).IsRequired();
    }
}
