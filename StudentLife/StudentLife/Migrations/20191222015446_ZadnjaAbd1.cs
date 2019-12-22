using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentLife.Migrations
{
    public partial class ZadnjaAbd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nagrade",
                columns: table => new
                {
                    NagradeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivNagrade = table.Column<string>(nullable: false),
                    BrojBodova = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrade", x => x.NagradeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nagrade");
        }
    }
}
