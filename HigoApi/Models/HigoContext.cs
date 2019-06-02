using Microsoft.EntityFrameworkCore;

namespace HigoApi.Models
{
    public partial class HigoContext : DbContext
    {
        public HigoContext()
        {
        }

        public HigoContext(DbContextOptions<HigoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cilindrada> Cilindrada { get; set; }
        public virtual DbSet<Combustible> Combustible { get; set; }
        public virtual DbSet<Control> Control { get; set; }
        public virtual DbSet<EstadoOperacion> EstadoOperacion { get; set; }
        public virtual DbSet<EstadoVehiculo> EstadoVehiculo { get; set; }
        public virtual DbSet<Locacion> Locacion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<MedioPago> MedioPago { get; set; }
        public virtual DbSet<ModeloMarca> ModeloMarca { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<TipoControl> TipoControl { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Se agrega configuracion de contexto a Startup.ConfigureServices().
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Cilindrada>(entity =>
            {
                entity.HasKey(e => e.IdCilindrada);

                entity.Property(e => e.IdCilindrada).HasColumnName("Id_Cilindrada");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Combustible>(entity =>
            {
                entity.HasKey(e => e.IdCombustible);

                entity.Property(e => e.IdCombustible).HasColumnName("Id_Combustible");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Control>(entity =>
            {
                entity.HasKey(e => e.IdControl);

                entity.Property(e => e.IdControl).HasColumnName("Id_Control");

                entity.Property(e => e.FechaHoraControl)
                    .HasColumnName("Fecha_Hora_Control")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.IdTipoControl).HasColumnName("Id_Tipo_Control");

                entity.Property(e => e.Km).HasColumnName("KM");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.Control)
                    .HasForeignKey(d => d.IdOperacion)
                    .HasConstraintName("FK_Control_Operacion");

                entity.HasOne(d => d.IdTipoControlNavigation)
                    .WithMany(p => p.Control)
                    .HasForeignKey(d => d.IdTipoControl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Control_Tipo_Control");
            });

            modelBuilder.Entity<EstadoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdEstadoOperacion);

                entity.ToTable("Estado_Operacion");

                entity.Property(e => e.IdEstadoOperacion).HasColumnName("Id_Estado_Operacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdEstadoVehiculo)
                    .HasName("PK__Estado_V__F2878F26D8E5AF8C");

                entity.ToTable("Estado_Vehiculo");

                entity.Property(e => e.IdEstadoVehiculo).HasColumnName("Id_Estado_Vehiculo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locacion>(entity =>
            {
                entity.HasKey(e => e.IdLocacion);

                entity.Property(e => e.IdLocacion).HasColumnName("Id_Locacion");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedioPago>(entity =>
            {
                entity.HasKey(e => e.IdMedioPago);

                entity.ToTable("Medio_Pago");

                entity.Property(e => e.IdMedioPago).HasColumnName("Id_Medio_Pago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModeloMarca>(entity =>
            {
                entity.HasKey(e => e.IdModeloMarca);

                entity.ToTable("Modelo_Marca");

                entity.Property(e => e.IdModeloMarca).HasColumnName("Id_Modelo_Marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdMarca).HasColumnName("Id_Marca");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.ModeloMarca)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modelo_Marca_Marca");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion);

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.FechaHoraDesde)
                    .HasColumnName("Fecha_Hora_Desde")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaHoraHasta)
                    .HasColumnName("Fecha_Hora_Hasta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAdquirente).HasColumnName("Id_Adquirente");

                entity.Property(e => e.IdEstadoOperacion).HasColumnName("Id_Estado_Operacion");

                entity.Property(e => e.IdMedioPago).HasColumnName("Id_Medio_Pago");

                entity.Property(e => e.IdVehiculo).HasColumnName("Id_Vehiculo");

                entity.Property(e => e.MontoAcordado)
                    .HasColumnName("Monto_Acordado")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MontoEfectivo)
                    .HasColumnName("Monto_Efectivo")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.NumeroComprobante).HasColumnName("Numero_Comprobante");

                entity.HasOne(d => d.IdAdquirenteNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdAdquirente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Adquirente");

                entity.HasOne(d => d.IdEstadoOperacionNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdEstadoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Estado_Operacion");

                entity.HasOne(d => d.IdMedioPagoNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdMedioPago)
                    .HasConstraintName("FK_Operacion_Medio_Pago");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Operacion_Vehiculo");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoControl>(entity =>
            {
                entity.HasKey(e => e.IdTipoControl);

                entity.ToTable("Tipo_Control");

                entity.Property(e => e.IdTipoControl).HasColumnName("Id_Tipo_Control");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehiculo)
                    .HasName("PK__Tipo_Veh__C92BD73119E8076E");

                entity.ToTable("Tipo_Vehiculo");

                entity.Property(e => e.IdTipoVehiculo).HasColumnName("Id_Tipo_Vehiculo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("Fecha_Alta")
                    .HasColumnType("date");

                entity.Property(e => e.IdLocacion).HasColumnName("Id_Locacion");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocacionNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdLocacion)
                    .HasConstraintName("FK_Usuario_Locacion");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_Usuario_Perfil");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__46DBF4B46584BD66");

                entity.Property(e => e.IdVehiculo).HasColumnName("Id_Vehiculo");

                entity.Property(e => e.Abs).HasColumnName("ABS");

                entity.Property(e => e.Ac).HasColumnName("AC");

                entity.Property(e => e.CierreCentralizado).HasColumnName("Cierre_Centralizado");

                entity.Property(e => e.ControlTraccion).HasColumnName("Control_Traccion");

                entity.Property(e => e.Da).HasColumnName("DA");

                entity.Property(e => e.Dh).HasColumnName("DH");

                entity.Property(e => e.IdCilindrada).HasColumnName("Id_Cilindrada");

                entity.Property(e => e.IdCombustible).HasColumnName("Id_Combustible");

                entity.Property(e => e.IdEstadoVehiculo).HasColumnName("Id_Estado_Vehiculo");

                entity.Property(e => e.IdLocacion).HasColumnName("Id_Locacion");

                entity.Property(e => e.IdModeloMarca).HasColumnName("Id_Modelo_Marca");

                entity.Property(e => e.IdPrestador).HasColumnName("Id_Prestador");

                entity.Property(e => e.IdTipoVehiculo).HasColumnName("Id_Tipo_Vehiculo");

                entity.Property(e => e.RompenieblasDelantero).HasColumnName("Rompenieblas_Delantero");

                entity.Property(e => e.RompenieblasTrasero).HasColumnName("Rompenieblas_Trasero");

                entity.Property(e => e.TapizadoCuero).HasColumnName("Tapizado_Cuero");

                entity.HasOne(d => d.IdCilindradaNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdCilindrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Cilindrada");

                entity.HasOne(d => d.IdCombustibleNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdCombustible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Combustible");

                entity.HasOne(d => d.IdEstadoVehiculoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdEstadoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Estado_Vehiculo");

                entity.HasOne(d => d.IdLocacionNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdLocacion)
                    .HasConstraintName("FK_Vehiculo_Locacion");

                entity.HasOne(d => d.IdModeloMarcaNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdModeloMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_Modelo_Marca");

                entity.HasOne(d => d.IdPrestadorNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdPrestador)
                    .HasConstraintName("FK_Vehiculo_Usuario");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .HasConstraintName("FK_Vehiculo_Tipo_Vehiculo");
            });
        }
    }
}