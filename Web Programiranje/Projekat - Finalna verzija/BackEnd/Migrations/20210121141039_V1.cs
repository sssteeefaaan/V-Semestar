using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnirID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Maksimalni_Broj_Učesnika = table.Column<int>(type: "int", nullable: false),
                    Pobednik = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Turnir",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxDisciplina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnir", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Učesnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplinaID = table.Column<int>(type: "int", nullable: false),
                    TurnirID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Brzina = table.Column<int>(type: "int", nullable: false),
                    Rang = table.Column<int>(type: "int", nullable: true),
                    Pozicija = table.Column<int>(type: "int", nullable: true),
                    Selected = table.Column<bool>(type: "bit", nullable: true),
                    Compete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Učesnik", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Turnir");

            migrationBuilder.DropTable(
                name: "Učesnik");
        }
    }
}
