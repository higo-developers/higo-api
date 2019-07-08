using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class RefactorLocacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Locacion",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Id_Locacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Id_Locacion",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partido",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Partido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "Id_Locacion",
                table: "Usuario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id_Locacion",
                table: "Usuario",
                column: "Id_Locacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Locacion",
                table: "Usuario",
                column: "Id_Locacion",
                principalTable: "Locacion",
                principalColumn: "Id_Locacion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
