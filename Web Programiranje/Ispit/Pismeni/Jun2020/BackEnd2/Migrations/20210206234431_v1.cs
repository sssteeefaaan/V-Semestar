using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd2.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maksimalnibrojsetova = table.Column<int>(name: "Maksimalni broj setova", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mec", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Igrac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MecID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godine = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Igrac_Mec_MecID",
                        column: x => x.MecID,
                        principalTable: "Mec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrednost = table.Column<int>(type: "int", nullable: false),
                    IgracID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Poen_Igrac_IgracID",
                        column: x => x.IgracID,
                        principalTable: "Igrac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igrac_MecID",
                table: "Igrac",
                column: "MecID");

            migrationBuilder.CreateIndex(
                name: "IX_Poen_IgracID",
                table: "Poen",
                column: "IgracID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poen");

            migrationBuilder.DropTable(
                name: "Igrac");

            migrationBuilder.DropTable(
                name: "Mec");
        }
    }
}
