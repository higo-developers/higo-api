using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class OrigenUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origen",
                table: "Usuario",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origen",
                table: "Usuario");
        }
    }
}
