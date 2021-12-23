using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1215EFCoreShopApp.Migrations
{
    public partial class bringitbackagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShopItemTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 19, 31, 13, 65, DateTimeKind.Utc).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 19, 31, 13, 65, DateTimeKind.Utc).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 19, 31, 13, 65, DateTimeKind.Utc).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 19, 31, 13, 65, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 19, 31, 13, 65, DateTimeKind.Utc).AddTicks(3276));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShopItemTags");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 18, 34, 22, 38, DateTimeKind.Utc).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 18, 34, 22, 38, DateTimeKind.Utc).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 18, 34, 22, 38, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 18, 34, 22, 38, DateTimeKind.Utc).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 23, 18, 34, 22, 38, DateTimeKind.Utc).AddTicks(8248));
        }
    }
}
