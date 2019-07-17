using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HigoApi.Migrations
{
    public partial class MercadoPagoEstructura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cilindrada",
                columns: table => new
                {
                    Id_Cilindrada = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cilindrada", x => x.Id_Cilindrada);
                });

            migrationBuilder.CreateTable(
                name: "Combustible",
                columns: table => new
                {
                    Id_Combustible = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustible", x => x.Id_Combustible);
                });

            migrationBuilder.CreateTable(
                name: "Control",
                columns: table => new
                {
                    Id_Control = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Operacion = table.Column<int>(nullable: true),
                    Fecha_Hora_Control_Inicial = table.Column<DateTime>(type: "datetime", nullable: true),
                    Funcionamiento_General_Final = table.Column<int>(nullable: true),
                    Funcionamiento_General_Inicial = table.Column<int>(nullable: true),
                    Fecha_Hora_Control_Final = table.Column<DateTime>(nullable: true),
                    Higiene_Externa_Final = table.Column<int>(nullable: true),
                    Higiene_Externa_Inicial = table.Column<int>(nullable: true),
                    Higiene_Interna_Final = table.Column<int>(nullable: true),
                    Higiene_Interna_Inicial = table.Column<int>(nullable: true),
                    Nivel_Combustible_Final = table.Column<int>(nullable: true),
                    Nivel_Combustible_Inicial = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control", x => x.Id_Control);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Operacion",
                columns: table => new
                {
                    Id_Estado_Operacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Operacion", x => x.Id_Estado_Operacion);
                });

            migrationBuilder.CreateTable(
                name: "Estado_Vehiculo",
                columns: table => new
                {
                    Id_Estado_Vehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estado_V__F2878F26D8E5AF8C", x => x.Id_Estado_Vehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "Medio_Pago",
                columns: table => new
                {
                    Id_Medio_Pago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medio_Pago", x => x.Id_Medio_Pago);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id_Perfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id_Perfil);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Vehiculo",
                columns: table => new
                {
                    Id_Tipo_Vehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tipo_Veh__C92BD73119E8076E", x => x.Id_Tipo_Vehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Operacion_Workflow",
                columns: table => new
                {
                    Id_Operacion_Workflow = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion_Accion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Id_Estado_Actual = table.Column<int>(nullable: false),
                    Id_Proximo_Estado = table.Column<int>(nullable: false),
                    Rol = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion_Workflow", x => x.Id_Operacion_Workflow);
                    table.ForeignKey(
                        name: "FK_Workflow_Operacion_Estado_Actual",
                        column: x => x.Id_Estado_Actual,
                        principalTable: "Estado_Operacion",
                        principalColumn: "Id_Estado_Operacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Operacion_Proximo_Estado",
                        column: x => x.Id_Proximo_Estado,
                        principalTable: "Estado_Operacion",
                        principalColumn: "Id_Estado_Operacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modelo_Marca",
                columns: table => new
                {
                    Id_Modelo_Marca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Id_Marca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_Marca", x => x.Id_Modelo_Marca);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_Marca",
                        column: x => x.Id_Marca,
                        principalTable: "Marca",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    DNI = table.Column<long>(nullable: true),
                    Id_Perfil = table.Column<int>(nullable: true),
                    Fecha_Alta = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Origen = table.Column<string>(maxLength: 30, nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Partido = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    EmailMP = table.Column<string>(nullable: true),
                    TokenMP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil",
                        column: x => x.Id_Perfil,
                        principalTable: "Perfil",
                        principalColumn: "Id_Perfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id_Vehiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Prestador = table.Column<int>(nullable: true),
                    Id_Modelo_Marca = table.Column<int>(nullable: false),
                    Id_Estado_Vehiculo = table.Column<int>(nullable: false),
                    Id_Combustible = table.Column<int>(nullable: false),
                    Id_Tipo_Vehiculo = table.Column<int>(nullable: true),
                    Id_Cilindrada = table.Column<int>(nullable: false),
                    Anno = table.Column<int>(nullable: true),
                    AC = table.Column<bool>(nullable: true),
                    DA = table.Column<bool>(nullable: true),
                    DH = table.Column<bool>(nullable: true),
                    Alarma = table.Column<bool>(nullable: true),
                    Cierre_Centralizado = table.Column<bool>(nullable: true),
                    Rompenieblas_Delantero = table.Column<bool>(nullable: true),
                    Rompenieblas_Trasero = table.Column<bool>(nullable: true),
                    Airbag = table.Column<bool>(nullable: true),
                    ABS = table.Column<bool>(nullable: true),
                    Control_Traccion = table.Column<bool>(nullable: true),
                    Tapizado_Cuero = table.Column<bool>(nullable: true),
                    Patente = table.Column<string>(maxLength: 15, nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Partido = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    PrecioPorHora = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__46DBF4B46584BD66", x => x.Id_Vehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Cilindrada",
                        column: x => x.Id_Cilindrada,
                        principalTable: "Cilindrada",
                        principalColumn: "Id_Cilindrada",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Combustible",
                        column: x => x.Id_Combustible,
                        principalTable: "Combustible",
                        principalColumn: "Id_Combustible",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Estado_Vehiculo",
                        column: x => x.Id_Estado_Vehiculo,
                        principalTable: "Estado_Vehiculo",
                        principalColumn: "Id_Estado_Vehiculo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Modelo_Marca",
                        column: x => x.Id_Modelo_Marca,
                        principalTable: "Modelo_Marca",
                        principalColumn: "Id_Modelo_Marca",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Usuario",
                        column: x => x.Id_Prestador,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Tipo_Vehiculo",
                        column: x => x.Id_Tipo_Vehiculo,
                        principalTable: "Tipo_Vehiculo",
                        principalColumn: "Id_Tipo_Vehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    Id_Operacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Adquirente = table.Column<int>(nullable: false),
                    Id_Vehiculo = table.Column<int>(nullable: false),
                    Id_Estado_Operacion = table.Column<int>(nullable: false),
                    Fecha_Hora_Desde = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_Hora_Hasta = table.Column<DateTime>(type: "datetime", nullable: true),
                    Monto_Acordado = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    Monto_Efectivo = table.Column<decimal>(type: "decimal(12, 2)", nullable: true),
                    Id_Medio_Pago = table.Column<int>(nullable: true),
                    Numero_Comprobante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.Id_Operacion);
                    table.ForeignKey(
                        name: "FK_Operacion_Adquirente",
                        column: x => x.Id_Adquirente,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacion_Estado_Operacion",
                        column: x => x.Id_Estado_Operacion,
                        principalTable: "Estado_Operacion",
                        principalColumn: "Id_Estado_Operacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacion_Medio_Pago",
                        column: x => x.Id_Medio_Pago,
                        principalTable: "Medio_Pago",
                        principalColumn: "Id_Medio_Pago",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operacion_Vehiculo",
                        column: x => x.Id_Vehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "Id_Vehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Mensaje = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    URL = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Operacion_MP",
                columns: table => new
                {
                    Id_Operacion_MP = table.Column<int>(nullable: false),
                    Id_Operacion_HIGO = table.Column<int>(nullable: false),
                    amount = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    collector_id = table.Column<int>(nullable: true),
                    payer_id = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    init_point = table.Column<string>(nullable: true),
                    status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion_MP", x => x.Id_Operacion_MP);
                    table.ForeignKey(
                        name: "FK_Operacion_MP_Operacion",
                        column: x => x.Id_Operacion_HIGO,
                        principalTable: "Operacion",
                        principalColumn: "Id_Operacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Control_Id_Operacion",
                table: "Control",
                column: "Id_Operacion");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Marca_Id_Marca",
                table: "Modelo_Marca",
                column: "Id_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_Id_Operacion",
                table: "Notificacion",
                column: "Id_Operacion");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacion_Id_Usuario",
                table: "Notificacion",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Id_Adquirente",
                table: "Operacion",
                column: "Id_Adquirente");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Id_Estado_Operacion",
                table: "Operacion",
                column: "Id_Estado_Operacion");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Id_Medio_Pago",
                table: "Operacion",
                column: "Id_Medio_Pago");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Id_Vehiculo",
                table: "Operacion",
                column: "Id_Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_MP_Id_Operacion_HIGO",
                table: "Operacion_MP",
                column: "Id_Operacion_HIGO");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Workflow_Id_Estado_Actual",
                table: "Operacion_Workflow",
                column: "Id_Estado_Actual");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_Workflow_Id_Proximo_Estado",
                table: "Operacion_Workflow",
                column: "Id_Proximo_Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id_Perfil",
                table: "Usuario",
                column: "Id_Perfil");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Cilindrada",
                table: "Vehiculo",
                column: "Id_Cilindrada");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Combustible",
                table: "Vehiculo",
                column: "Id_Combustible");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Estado_Vehiculo",
                table: "Vehiculo",
                column: "Id_Estado_Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Modelo_Marca",
                table: "Vehiculo",
                column: "Id_Modelo_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Prestador",
                table: "Vehiculo",
                column: "Id_Prestador");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Id_Tipo_Vehiculo",
                table: "Vehiculo",
                column: "Id_Tipo_Vehiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Control");

            migrationBuilder.DropTable(
                name: "Notificacion");

            migrationBuilder.DropTable(
                name: "Operacion_MP");

            migrationBuilder.DropTable(
                name: "Operacion_Workflow");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Estado_Operacion");

            migrationBuilder.DropTable(
                name: "Medio_Pago");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Cilindrada");

            migrationBuilder.DropTable(
                name: "Combustible");

            migrationBuilder.DropTable(
                name: "Estado_Vehiculo");

            migrationBuilder.DropTable(
                name: "Modelo_Marca");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Tipo_Vehiculo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
