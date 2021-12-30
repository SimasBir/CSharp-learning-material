using Microsoft.EntityFrameworkCore.Migrations;

namespace _1228RegistrationApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: true),
                    ValueGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prompts_Values_ValueId",
                        column: x => x.ValueId,
                        principalTable: "Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "Description", "ValueGroupId", "ValueId" },
                values: new object[,]
                {
                    { 1, "Reikia atlikti rangos darbus", 1, null },
                    { 2, "Rangos Darbus atliks", 2, null },
                    { 3, "Verslo klientas", 1, null },
                    { 4, "Skaičiavimo metodas", 3, null },
                    { 5, "Svarbus klientas", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Description", "ValueGroup" },
                values: new object[,]
                {
                    { 1, "Taip", 1 },
                    { 2, "Ne", 1 },
                    { 3, "Metinis rangovas", 2 },
                    { 4, "Operatorius", 2 },
                    { 5, "Automatinis", 3 },
                    { 6, "Manualus", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prompts_ValueId",
                table: "Prompts",
                column: "ValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prompts");

            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
