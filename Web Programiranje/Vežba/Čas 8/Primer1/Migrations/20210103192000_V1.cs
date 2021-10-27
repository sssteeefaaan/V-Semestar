using Microsoft.EntityFrameworkCore.Migrations;

namespace Primer1.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZooVrt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    N = table.Column<int>(type: "int", nullable: false),
                    M = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooVrt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    MaxKapacitet = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    VrtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lokacija_ZooVrt_VrtID",
                        column: x => x.VrtID,
                        principalTable: "ZooVrt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_VrtID",
                table: "Lokacija",
                column: "VrtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "ZooVrt");
        }
    }
}
