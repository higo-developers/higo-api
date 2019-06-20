using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Cilindrada
    {
        public Cilindrada()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdCilindrada { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
