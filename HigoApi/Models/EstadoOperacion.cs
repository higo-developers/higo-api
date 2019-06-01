using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class EstadoOperacion
    {
        public EstadoOperacion()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int IdEstadoOperacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
