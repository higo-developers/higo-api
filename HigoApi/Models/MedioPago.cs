using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class MedioPago
    {
        public MedioPago()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int IdMedioPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
