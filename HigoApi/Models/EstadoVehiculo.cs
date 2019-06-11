using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class EstadoVehiculo
    {
        public EstadoVehiculo()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdEstadoVehiculo { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
