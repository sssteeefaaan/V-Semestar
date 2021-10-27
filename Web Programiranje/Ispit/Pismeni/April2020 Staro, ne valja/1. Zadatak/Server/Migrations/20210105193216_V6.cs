using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polica_Video Klub_VideoKlubID",
                table: "Polica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polica",
                table: "Polica");

            migrationBuilder.RenameColumn(
                name: "VideoKlubID",
                table: "Polica",
                newName: "Video Klub ID");

            migrationBuilder.RenameIndex(
                name: "IX_Polica_VideoKlubID",
                table: "Polica",
                newName: "IX_Polica_Video Klub ID");

            migrationBuilder.AlterColumn<int>(
                name: "Video Klub ID",
                table: "Polica",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polica",
                table: "Polica",
                columns: new[] { "Oznaka", "Video Klub ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Polica_Video Klub_Video Klub ID",
                table: "Polica",
                column: "Video Klub ID",
                principalTable: "Video Klub",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polica_Video Klub_Video Klub ID",
                table: "Polica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polica",
                table: "Polica");

            migrationBuilder.RenameColumn(
                name: "Video Klub ID",
                table: "Polica",
                newName: "VideoKlubID");

            migrationBuilder.RenameIndex(
                name: "IX_Polica_Video Klub ID",
                table: "Polica",
                newName: "IX_Polica_VideoKlubID");

            migrationBuilder.AlterColumn<int>(
                name: "VideoKlubID",
                table: "Polica",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polica",
                table: "Polica",
                column: "Oznaka");

            migrationBuilder.AddForeignKey(
                name: "FK_Polica_Video Klub_VideoKlubID",
                table: "Polica",
                column: "VideoKlubID",
                principalTable: "Video Klub",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
