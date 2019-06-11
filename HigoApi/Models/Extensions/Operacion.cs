using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models
{
    public partial class Operacion
    {
        public Operacion(Operacion operacion)
        {
            this.FechaHoraDesde = operacion.FechaHoraDesde;
            this.FechaHoraHasta = operacion.FechaHoraHasta;
            this.IdAdquirente = operacion.IdAdquirente;
            this.IdEstadoOperacion = 0;
            this.IdVehiculo = operacion.IdVehiculo;
            this.MontoAcordado = operacion.MontoAcordado;
        }
    }
}
