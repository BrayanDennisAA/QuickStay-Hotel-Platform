using Microsoft.EntityFrameworkCore;
using QuickStay.Api.Modules.Catalog.Domain.Entities;

namespace QuickStay.Api.Modules.Catalog.Infrastructure.Persistence.Seed;

public static class RoomTypeSeed
{
    public static void SeedRoomType(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            (
                Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                "Standard",
                2,
                85m
            ),
            new RoomType
            (
                Guid.Parse("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
                Guid.Parse("11111111-1111-1111-1111-111111111111"),
                "Deluxe",
                3,
                120m
            ),
            new RoomType
            (
                Guid.Parse("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                "Standard",
                2,
                70m
            ),
            new RoomType
            (
                Guid.Parse("bbbbbbb2-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
                Guid.Parse("22222222-2222-2222-2222-222222222222"),
                "Suite",
                4,
                150)
            ,
            new RoomType
            (
                Guid.Parse("ccccccc1-cccc-cccc-cccc-ccccccccccc1"),
                Guid.Parse("33333333-3333-3333-3333-333333333333"),
                "Standard",
                2,
                95m)

        );
    }
}