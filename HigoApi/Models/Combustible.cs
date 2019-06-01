using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Combustible
    {
        public Combustible()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdCombustible { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
