using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Modules.Catalog.Domain.Entities;

namespace QuickStay.Api.Modules.Catalog.Infrastructure.Persistence.Seed;

public static class HotelSeed
{
    public static void SeedHotels(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Andes Plaza Hotel", "Bogota", "Colombia", true),
            new Hotel
            (
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                 "Pacific View Suites",
                 "Lima",
                 "Peru",
                 true
            ),
            new Hotel
            (
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                 "Patagonia Urban Stay",
                 "Santiago",
                 "Chile",
                 true
            )
        );
    }
}