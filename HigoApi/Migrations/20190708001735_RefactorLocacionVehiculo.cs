using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class RefactorLocacionVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Locacion",
                table: "Vehiculo");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_Id_Locacion",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Id_Locacion",
                table: "Vehiculo");

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partido",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Vehiculo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Partido",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Vehiculo");

            migrationBuilder.AddColumn<int>(
                name: "Id_Locacion",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Locacion",
                table: "Vehiculo",
                column: "Id_Locacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Locacion",
                table: "Vehiculo",
                column: "Id_Locacion",
                principalTable: "Locacion",
                principalColumn: "Id_Locacion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
