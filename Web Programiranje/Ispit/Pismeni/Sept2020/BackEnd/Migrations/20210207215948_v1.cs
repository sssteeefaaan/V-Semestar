using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zoo Vrt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    N = table.Column<int>(type: "int", nullable: false),
                    M = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    TipoviStanista = table.Column<string>(name: "Tipovi Stanista", type: "nvarchar(max)", nullable: true),
                    BojeStanista = table.Column<string>(name: "Boje Stanista", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoo Vrt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stanište",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZooVrtID = table.Column<int>(type: "int", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Trenutno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanište", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stanište_Zoo Vrt_ZooVrtID",
                        column: x => x.ZooVrtID,
                        principalTable: "Zoo Vrt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stanište_ZooVrtID",
                table: "Stanište",
                column: "ZooVrtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stanište");

            migrationBuilder.DropTable(
                name: "Zoo Vrt");
        }
    }
}
