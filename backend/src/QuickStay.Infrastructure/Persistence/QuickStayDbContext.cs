using Microsoft.EntityFrameworkCore;
using QuickStay.Domain.Entities;
using QuickStay.Infrastructure.Configurations;

namespace QuickStay.Infrastructure.Persistence;

public class QuickStayDbContext : DbContext
{
    public QuickStayDbContext(DbContextOptions<QuickStayDbContext> options) : base(options)
    {
    }

    public DbSet<Hotel> Hotels => Set<Hotel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new HotelConfiguration());
    }

}
