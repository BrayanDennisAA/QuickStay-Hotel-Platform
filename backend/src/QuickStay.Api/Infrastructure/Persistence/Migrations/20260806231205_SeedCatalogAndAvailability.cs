using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuickStay.Api.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalogAndAvailability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "availability_inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HotelId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalRooms = table.Column<int>(type: "integer", nullable: false),
                    ReservedRooms = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availability_inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalog_hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog_hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalog_room_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HotelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalog_room_types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalog_room_types_catalog_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "catalog_hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "availability_inventory",
                columns: new[] { "Id", "Date", "HotelId", "ReservedRooms", "RoomTypeId", "TotalRooms" },
                values: new object[,]
                {
                    { new Guid("90000000-0000-0000-0000-000000000001"), new DateOnly(2026, 8, 1), new Guid("11111111-1111-1111-1111-111111111111"), 3, new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), 12 },
                    { new Guid("90000000-0000-0000-0000-000000000002"), new DateOnly(2026, 8, 1), new Guid("22222222-2222-2222-2222-222222222222"), 2, new Guid("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), 10 },
                    { new Guid("90000000-0000-0000-0000-000000000003"), new DateOnly(2026, 8, 2), new Guid("11111111-1111-1111-1111-111111111111"), 12, new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), 12 },
                    { new Guid("90000000-0000-0000-0000-000000000004"), new DateOnly(2026, 8, 2), new Guid("22222222-2222-2222-2222-222222222222"), 10, new Guid("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), 10 }
                });

            migrationBuilder.InsertData(
                table: "catalog_hotels",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Bogota", "Colombia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Andes Plaza Hotel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Lima", "Peru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pacific View Suites", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Santiago", "Chile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Patagonia Urban Stay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "catalog_room_types",
                columns: new[] { "Id", "BasePrice", "Capacity", "HotelId", "Name" },
                values: new object[,]
                {
                    { new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), 85m, 2, new Guid("11111111-1111-1111-1111-111111111111"), "Standard" },
                    { new Guid("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), 120m, 3, new Guid("11111111-1111-1111-1111-111111111111"), "Deluxe" },
                    { new Guid("bbbbbbb1-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), 70m, 2, new Guid("22222222-2222-2222-2222-222222222222"), "Standard" },
                    { new Guid("bbbbbbb2-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), 150m, 4, new Guid("22222222-2222-2222-2222-222222222222"), "Suite" },
                    { new Guid("ccccccc1-cccc-cccc-cccc-ccccccccccc1"), 95m, 2, new Guid("33333333-3333-3333-3333-333333333333"), "Standard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_availability_inventory_HotelId_RoomTypeId_Date",
                table: "availability_inventory",
                columns: new[] { "HotelId", "RoomTypeId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_catalog_hotels_City_IsActive",
                table: "catalog_hotels",
                columns: new[] { "City", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_catalog_room_types_HotelId",
                table: "catalog_room_types",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "availability_inventory");

            migrationBuilder.DropTable(
                name: "catalog_room_types");

            migrationBuilder.DropTable(
                name: "catalog_hotels");
        }
    }
}
