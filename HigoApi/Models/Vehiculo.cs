using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int IdVehiculo { get; set; }
        public int? IdPrestador { get; set; }
        public int IdModeloMarca { get; set; }
        public int IdEstadoVehiculo { get; set; }
        public int IdCombustible { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public int IdCilindrada { get; set; }
        public int? Anno { get; set; }
        public bool? Ac { get; set; }
        public bool? Da { get; set; }
        public bool? Dh { get; set; }
        public bool? Alarma { get; set; }
        public bool? CierreCentralizado { get; set; }
        public bool? RompenieblasDelantero { get; set; }
        public bool? RompenieblasTrasero { get; set; }
        public bool? Airbag { get; set; }
        public bool? Abs { get; set; }
        public bool? ControlTraccion { get; set; }
        public bool? TapizadoCuero { get; set; }
        public string Patente { get; set; }
        public string Latitud { get; set; }
        public string Localidad { get; set; }
        public string Longitud { get; set; }
        public string Pais { get; set; }
        public string Partido { get; set; }
        public string Provincia { get; set; }
        public double? PrecioPorHora { get; set; }

        public virtual Cilindrada IdCilindradaNavigation { get; set; }
        public virtual Combustible IdCombustibleNavigation { get; set; }
        public virtual EstadoVehiculo IdEstadoVehiculoNavigation { get; set; }
        public virtual ModeloMarca IdModeloMarcaNavigation { get; set; }
        public virtual Usuario IdPrestadorNavigation { get; set; }
        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
