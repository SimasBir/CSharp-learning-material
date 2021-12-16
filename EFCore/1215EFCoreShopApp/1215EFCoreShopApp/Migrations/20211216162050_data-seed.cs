using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1215EFCoreShopApp.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "ExpiryDate", "Name", "ShopId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(4886), "Phone", 1 },
                    { 2, new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5276), "Bread", 2 },
                    { 3, new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5280), "TV", 1 },
                    { 4, new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5281), "Milk", 2 },
                    { 5, new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5283), "Beef", 2 }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Groceries" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
