using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentLife.Migrations
{
    public partial class MojaMigracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Koordinate",
                table: "Marker",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Koordinate",
                table: "Marker");
        }
    }
}
