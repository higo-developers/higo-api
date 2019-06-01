using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Operacion
    {
        public Operacion()
        {
            Control = new HashSet<Control>();
        }

        public int IdOperacion { get; set; }
        public int IdAdquirente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdEstadoOperacion { get; set; }
        public DateTime? FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public decimal? MontoAcordado { get; set; }
        public decimal? MontoEfectivo { get; set; }
        public int? IdMedioPago { get; set; }
        public int? NumeroComprobante { get; set; }

        public virtual Usuario IdAdquirenteNavigation { get; set; }
        public virtual EstadoOperacion IdEstadoOperacionNavigation { get; set; }
        public virtual MedioPago IdMedioPagoNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
        public virtual ICollection<Control> Control { get; set; }
    }
}
