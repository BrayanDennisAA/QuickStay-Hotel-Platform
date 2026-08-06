using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Modules.Availability.Domain.Entities;

namespace QuickStay.Api.Modules.Availability.Infrastructure.Persistence.Seed;

public static class InventorySeed
{
    public static void SeedInventories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>().HasData(
            // Día 1
            new Inventory (
                Guid.Parse("90000000-0000-0000-0000-000000000001"), 
                Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), 
                new DateOnly(2026, 8, 1), 12, 3),
            new Inventory(
                Guid.Parse("90000000-0000-0000-0000-000000000002"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Guid.Parse("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                new DateOnly(2026, 8, 1),
                10, 2),
            // Día 2
            new Inventory(
                Guid.Parse("90000000-0000-0000-0000-000000000003"),
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                new DateOnly(2026, 8, 2),
                12, 12),
            new Inventory(
                Guid.Parse("90000000-0000-0000-0000-000000000004"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Guid.Parse("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                new DateOnly(2026, 8, 2),
                10, 10)
        );
    }
}