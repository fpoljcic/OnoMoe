using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentLife.Migrations
{
    public partial class MojaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Bodovi = table.Column<int>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Voznja",
                columns: table => new
                {
                    VoznjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    VrijemePolaska = table.Column<DateTime>(nullable: false),
                    PocetakRute = table.Column<string>(nullable: false),
                    KrajRute = table.Column<string>(nullable: false),
                    BrojMjesta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voznja", x => x.VoznjaID);
                    table.ForeignKey(
                        name: "FK_Voznja_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marker",
                columns: table => new
                {
                    MarkerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    VoznjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marker", x => x.MarkerID);
                    table.ForeignKey(
                        name: "FK_Marker_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Marker_Voznja_VoznjaID",
                        column: x => x.VoznjaID,
                        principalTable: "Voznja",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marker_StudentID",
                table: "Marker",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Marker_VoznjaID",
                table: "Marker",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznja_StudentID",
                table: "Voznja",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marker");

            migrationBuilder.DropTable(
                name: "Voznja");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
