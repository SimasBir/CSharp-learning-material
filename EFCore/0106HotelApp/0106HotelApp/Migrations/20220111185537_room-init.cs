using Microsoft.EntityFrameworkCore.Migrations;

namespace _0106HotelApp.Migrations
{
    public partial class roominit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsCleaning",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedsCleaning",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Rooms");
        }
    }
}
