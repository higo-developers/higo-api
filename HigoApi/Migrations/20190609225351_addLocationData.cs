using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class addLocationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Locacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Locacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Partido",
                table: "Locacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Locacion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Locacion");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Locacion");

            migrationBuilder.DropColumn(
                name: "Partido",
                table: "Locacion");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Locacion");
        }
    }
}
