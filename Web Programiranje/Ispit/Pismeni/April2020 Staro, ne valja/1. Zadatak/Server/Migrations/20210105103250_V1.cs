using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video Klub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video Klub", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polica",
                columns: table => new
                {
                    Oznaka = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Curr = table.Column<int>(type: "int", nullable: false),
                    VideoKlubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polica", x => x.Oznaka);
                    table.ForeignKey(
                        name: "FK_Polica_Video Klub_VideoKlubID",
                        column: x => x.VideoKlubID,
                        principalTable: "Video Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polica_VideoKlubID",
                table: "Polica",
                column: "VideoKlubID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polica");

            migrationBuilder.DropTable(
                name: "Video Klub");
        }
    }
}
