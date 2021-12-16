using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1215EFCoreShopApp.Migrations
{
    public partial class addedrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 24, 34, 606, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 24, 34, 606, DateTimeKind.Utc).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 24, 34, 606, DateTimeKind.Utc).AddTicks(1161));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 24, 34, 606, DateTimeKind.Utc).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 24, 34, 606, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItems_Shops_ShopId",
                table: "ShopItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopItems_ShopId",
                table: "ShopItems");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "ExpiryDate",
                value: new DateTime(2021, 12, 16, 16, 20, 49, 930, DateTimeKind.Utc).AddTicks(5283));
        }
    }
}
