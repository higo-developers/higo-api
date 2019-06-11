using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class Agregado_ColumnaCodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Tipo_Vehiculo",
                nullable: false
                );

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Tipo_Control",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Perfil",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Medio_Pago",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Marca",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Estado_Vehiculo",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Estado_Operacion",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Combustible",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Cilindrada",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Tipo_Vehiculo");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Tipo_Control");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Medio_Pago");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Marca");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Estado_Vehiculo");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Estado_Operacion");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Combustible");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Cilindrada");
        }
    }
}
