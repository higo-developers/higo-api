using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class Notificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notificacion",
                columns: table => new
                {
                    Id_Notificacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Id_Operacion = table.Column<int>(nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Leida = table.Column<bool>(nullable: true),
                    Borrada = table.Column<bool>(nullable: true),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Mensaje = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacion", x => x.Id_Notificacion);
                    table.ForeignKey(
                        name: "FK_Notificacion_Operacion",
                        column: x => x.Id_Operacion,
                        principalTable: "Operacion",
                        principalColumn: "Id_Operacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacion_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_Id_Operacion",
                table: "Notificacion",
                column: "Id_Operacion");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_Id_Usuario",
                table: "Notificacion",
                column: "Id_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacion");
        }
    }
}
