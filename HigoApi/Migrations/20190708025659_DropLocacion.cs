using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class DropLocacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacion",
                columns: table => new
                {
                    Id_Locacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitud = table.Column<string>(nullable: false),
                    Localidad = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: true),
                    Partido = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacion", x => x.Id_Locacion);
                });
        }
    }
}
