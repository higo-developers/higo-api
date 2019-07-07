using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class NotificacionesCampoURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrada",
                table: "Notificacion");

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Notificacion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Notificacion");

            migrationBuilder.AddColumn<bool>(
                name: "Borrada",
                table: "Notificacion",
                nullable: true);
        }
    }
}
