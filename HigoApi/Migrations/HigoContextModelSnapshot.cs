﻿// <auto-generated />

using System;
using HigoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HigoApi.Migrations
{
    [DbContext(typeof(HigoContext))]
    partial class HigoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HigoApi.Models.Cilindrada", b =>
                {
                    b.Property<int>("IdCilindrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Cilindrada")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdCilindrada");

                    b.ToTable("Cilindrada");
                });

            modelBuilder.Entity("HigoApi.Models.Combustible", b =>
                {
                    b.Property<int>("IdCombustible")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Combustible")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdCombustible");

                    b.ToTable("Combustible");
                });

            modelBuilder.Entity("HigoApi.Models.Control", b =>
                {
                    b.Property<int>("IdControl")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Control")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaHoraControl")
                        .HasColumnName("Fecha_Hora_Control")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdOperacion")
                        .HasColumnName("Id_Operacion");

                    b.Property<int>("IdTipoControl")
                        .HasColumnName("Id_Tipo_Control");

                    b.Property<long?>("Km")
                        .HasColumnName("KM");

                    b.HasKey("IdControl");

                    b.HasIndex("IdOperacion");

                    b.HasIndex("IdTipoControl");

                    b.ToTable("Control");
                });

            modelBuilder.Entity("HigoApi.Models.EstadoOperacion", b =>
                {
                    b.Property<int>("IdEstadoOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Estado_Operacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdEstadoOperacion");

                    b.ToTable("Estado_Operacion");
                });

            modelBuilder.Entity("HigoApi.Models.EstadoVehiculo", b =>
                {
                    b.Property<int>("IdEstadoVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Estado_Vehiculo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100);

                    b.HasKey("IdEstadoVehiculo")
                        .HasName("PK__Estado_V__F2878F26D8E5AF8C");

                    b.ToTable("Estado_Vehiculo");
                });

            modelBuilder.Entity("HigoApi.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Marca")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdMarca");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("HigoApi.Models.MedioPago", b =>
                {
                    b.Property<int>("IdMedioPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Medio_Pago")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdMedioPago");

                    b.ToTable("Medio_Pago");
                });

            modelBuilder.Entity("HigoApi.Models.ModeloMarca", b =>
                {
                    b.Property<int>("IdModeloMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Modelo_Marca")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<int>("IdMarca")
                        .HasColumnName("Id_Marca");

                    b.HasKey("IdModeloMarca");

                    b.HasIndex("IdMarca");

                    b.ToTable("Modelo_Marca");
                });

            modelBuilder.Entity("HigoApi.Models.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Notificacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnName("Fecha_Creacion")
                        .HasColumnType("datetime");

                    b.Property<int>("IdOperacion")
                        .HasColumnName("Id_Operacion");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("Id_Usuario");

                    b.Property<bool?>("Leida");

                    b.Property<string>("Mensaje")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("URL");

                    b.HasKey("IdNotificacion");

                    b.HasIndex("IdOperacion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Notificacion");
                });

            modelBuilder.Entity("HigoApi.Models.Operacion", b =>
                {
                    b.Property<int>("IdOperacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Operacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaHoraDesde")
                        .HasColumnName("Fecha_Hora_Desde")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaHoraHasta")
                        .HasColumnName("Fecha_Hora_Hasta")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAdquirente")
                        .HasColumnName("Id_Adquirente");

                    b.Property<int>("IdEstadoOperacion")
                        .HasColumnName("Id_Estado_Operacion");

                    b.Property<int?>("IdMedioPago")
                        .HasColumnName("Id_Medio_Pago");

                    b.Property<int>("IdVehiculo")
                        .HasColumnName("Id_Vehiculo");

                    b.Property<decimal?>("MontoAcordado")
                        .HasColumnName("Monto_Acordado")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("MontoEfectivo")
                        .HasColumnName("Monto_Efectivo")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<int?>("NumeroComprobante")
                        .HasColumnName("Numero_Comprobante");

                    b.HasKey("IdOperacion");

                    b.HasIndex("IdAdquirente");

                    b.HasIndex("IdEstadoOperacion");

                    b.HasIndex("IdMedioPago");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Operacion");
                });

            modelBuilder.Entity("HigoApi.Models.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Perfil")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("HigoApi.Models.TipoControl", b =>
                {
                    b.Property<int>("IdTipoControl")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Tipo_Control")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdTipoControl");

                    b.ToTable("Tipo_Control");
                });

            modelBuilder.Entity("HigoApi.Models.TipoVehiculo", b =>
                {
                    b.Property<int>("IdTipoVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Tipo_Vehiculo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdTipoVehiculo")
                        .HasName("PK__Tipo_Veh__C92BD73119E8076E");

                    b.ToTable("Tipo_Vehiculo");
                });

            modelBuilder.Entity("HigoApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Usuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<long?>("Dni")
                        .HasColumnName("DNI");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnName("Fecha_Alta")
                        .HasColumnType("date");

                    b.Property<int?>("IdPerfil")
                        .HasColumnName("Id_Perfil");

                    b.Property<string>("Latitud");

                    b.Property<string>("Localidad");

                    b.Property<string>("Longitud");

                    b.Property<string>("Nombre");

                    b.Property<string>("Origen")
                        .HasMaxLength(30);

                    b.Property<string>("Pais");

                    b.Property<string>("Partido");

                    b.Property<string>("Password");

                    b.Property<string>("Provincia");

                    b.Property<string>("Telefono");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("HigoApi.Models.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id_Vehiculo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Abs")
                        .HasColumnName("ABS");

                    b.Property<bool?>("Ac")
                        .HasColumnName("AC");

                    b.Property<bool?>("Airbag");

                    b.Property<bool?>("Alarma");

                    b.Property<int?>("Anno");

                    b.Property<bool?>("CierreCentralizado")
                        .HasColumnName("Cierre_Centralizado");

                    b.Property<bool?>("ControlTraccion")
                        .HasColumnName("Control_Traccion");

                    b.Property<bool?>("Da")
                        .HasColumnName("DA");

                    b.Property<bool?>("Dh")
                        .HasColumnName("DH");

                    b.Property<int>("IdCilindrada")
                        .HasColumnName("Id_Cilindrada");

                    b.Property<int>("IdCombustible")
                        .HasColumnName("Id_Combustible");

                    b.Property<int>("IdEstadoVehiculo")
                        .HasColumnName("Id_Estado_Vehiculo");

                    b.Property<int>("IdModeloMarca")
                        .HasColumnName("Id_Modelo_Marca");

                    b.Property<int?>("IdPrestador")
                        .HasColumnName("Id_Prestador");

                    b.Property<int?>("IdTipoVehiculo")
                        .HasColumnName("Id_Tipo_Vehiculo");

                    b.Property<string>("Latitud");

                    b.Property<string>("Localidad");

                    b.Property<string>("Longitud");

                    b.Property<string>("Pais");

                    b.Property<string>("Partido");

                    b.Property<string>("Patente")
                        .HasMaxLength(15);

                    b.Property<string>("Provincia");

                    b.Property<bool?>("RompenieblasDelantero")
                        .HasColumnName("Rompenieblas_Delantero");

                    b.Property<bool?>("RompenieblasTrasero")
                        .HasColumnName("Rompenieblas_Trasero");

                    b.Property<bool?>("TapizadoCuero")
                        .HasColumnName("Tapizado_Cuero");

                    b.HasKey("IdVehiculo")
                        .HasName("PK__Vehiculo__46DBF4B46584BD66");

                    b.HasIndex("IdCilindrada");

                    b.HasIndex("IdCombustible");

                    b.HasIndex("IdEstadoVehiculo");

                    b.HasIndex("IdModeloMarca");

                    b.HasIndex("IdPrestador");

                    b.HasIndex("IdTipoVehiculo");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("HigoApi.Models.Control", b =>
                {
                    b.HasOne("HigoApi.Models.Operacion", "IdOperacionNavigation")
                        .WithMany("Control")
                        .HasForeignKey("IdOperacion")
                        .HasConstraintName("FK_Control_Operacion");

                    b.HasOne("HigoApi.Models.TipoControl", "IdTipoControlNavigation")
                        .WithMany("Control")
                        .HasForeignKey("IdTipoControl")
                        .HasConstraintName("FK_Control_Tipo_Control");
                });

            modelBuilder.Entity("HigoApi.Models.ModeloMarca", b =>
                {
                    b.HasOne("HigoApi.Models.Marca", "IdMarcaNavigation")
                        .WithMany("ModeloMarca")
                        .HasForeignKey("IdMarca")
                        .HasConstraintName("FK_Modelo_Marca_Marca");
                });

            modelBuilder.Entity("HigoApi.Models.Notificacion", b =>
                {
                    b.HasOne("HigoApi.Models.Operacion", "IdOperacionNavigation")
                        .WithMany("Notificacion")
                        .HasForeignKey("IdOperacion")
                        .HasConstraintName("FK_Notificacion_Operacion")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HigoApi.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Notificacion")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Notificacion_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HigoApi.Models.Operacion", b =>
                {
                    b.HasOne("HigoApi.Models.Usuario", "IdAdquirenteNavigation")
                        .WithMany("Operacion")
                        .HasForeignKey("IdAdquirente")
                        .HasConstraintName("FK_Operacion_Adquirente");

                    b.HasOne("HigoApi.Models.EstadoOperacion", "IdEstadoOperacionNavigation")
                        .WithMany("Operacion")
                        .HasForeignKey("IdEstadoOperacion")
                        .HasConstraintName("FK_Operacion_Estado_Operacion");

                    b.HasOne("HigoApi.Models.MedioPago", "IdMedioPagoNavigation")
                        .WithMany("Operacion")
                        .HasForeignKey("IdMedioPago")
                        .HasConstraintName("FK_Operacion_Medio_Pago");

                    b.HasOne("HigoApi.Models.Vehiculo", "IdVehiculoNavigation")
                        .WithMany("Operacion")
                        .HasForeignKey("IdVehiculo")
                        .HasConstraintName("FK_Operacion_Vehiculo");
                });

            modelBuilder.Entity("HigoApi.Models.Usuario", b =>
                {
                    b.HasOne("HigoApi.Models.Perfil", "IdPerfilNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdPerfil")
                        .HasConstraintName("FK_Usuario_Perfil");
                });

            modelBuilder.Entity("HigoApi.Models.Vehiculo", b =>
                {
                    b.HasOne("HigoApi.Models.Cilindrada", "IdCilindradaNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdCilindrada")
                        .HasConstraintName("FK_Vehiculo_Cilindrada");

                    b.HasOne("HigoApi.Models.Combustible", "IdCombustibleNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdCombustible")
                        .HasConstraintName("FK_Vehiculo_Combustible");

                    b.HasOne("HigoApi.Models.EstadoVehiculo", "IdEstadoVehiculoNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdEstadoVehiculo")
                        .HasConstraintName("FK_Vehiculo_Estado_Vehiculo");

                    b.HasOne("HigoApi.Models.ModeloMarca", "IdModeloMarcaNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdModeloMarca")
                        .HasConstraintName("FK_Vehiculo_Modelo_Marca");

                    b.HasOne("HigoApi.Models.Usuario", "IdPrestadorNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdPrestador")
                        .HasConstraintName("FK_Vehiculo_Usuario");

                    b.HasOne("HigoApi.Models.TipoVehiculo", "IdTipoVehiculoNavigation")
                        .WithMany("Vehiculo")
                        .HasForeignKey("IdTipoVehiculo")
                        .HasConstraintName("FK_Vehiculo_Tipo_Vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
