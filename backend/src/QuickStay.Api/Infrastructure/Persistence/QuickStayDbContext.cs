using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Modules.Availability.Domain.Entities;
using QuickStay.Api.Modules.Catalog.Domain.Entities;
using QuickStay.Api.Modules.Catalog.Infrastructure.Persistence.Configurations;
namespace QuickStay.Api.Infrastructure.Persistence;

public class QuickStayDbContext : DbContext
{
    public QuickStayDbContext(DbContextOptions<QuickStayDbContext> options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<Inventory> Inventories => Set<Inventory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new InvetoryConfiguration());
    }

}
