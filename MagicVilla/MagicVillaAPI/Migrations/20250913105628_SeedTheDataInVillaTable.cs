using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedTheDataInVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Pool, Wi-Fi, Air Conditioning", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with stunning ocean views, private pool, and modern amenities.", "https://unsplash.com/photos/white-and-grey-concrete-building-near-swimming-pool-under-clear-sky-during-daytime-2d4lAQAlbDA", "Azure Haven Villa", 8, 5000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Laundry machine, dryer,Smart TV or entertainment system", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with stunning sunset views, private pool, and modern amenities.", "https://unsplash.com/photos/white-and-brown-concrete-building-near-swimming-pool-during-daytime-GSL3IuuwJv8", "Sunset Shores Villa", 12, 50000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Wi-Fi/internet access,Gym or fitness area", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with stunning mountain views, private pool, and modern amenities.", "https://images.unsplash.com/photo-1568605114967-8130f3a36994?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", " Mountain Mist Villa", 13, 67800.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Comfortable beds and sofas,Home theater room", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with stunning sunset views, private pool, and modern amenities.", "https://unsplash.com/photos/a-large-pink-house-with-a-pond-in-front-of-it-S7bDOVuF4R8", " Regal Ridge Villa", 12, 23400.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Fully equipped kitchen,Jacuzzi or hot tub", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with private pool, and modern amenities.", "https://images.unsplash.com/photo-1564013799919-ab600027ffc6?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", " Urban Escape Villa", 10, 12000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
