using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Polica",
                table: "Polica");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Polica");

            migrationBuilder.AlterColumn<string>(
                name: "Oznaka",
                table: "Polica",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polica",
                table: "Polica",
                column: "Oznaka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Polica",
                table: "Polica");

            migrationBuilder.AlterColumn<string>(
                name: "Oznaka",
                table: "Polica",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Polica",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polica",
                table: "Polica",
                column: "ID");
        }
    }
}
