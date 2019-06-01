using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Locacion
    {
        public Locacion()
        {
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdLocacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
