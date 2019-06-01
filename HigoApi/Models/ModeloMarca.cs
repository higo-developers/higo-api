using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class ModeloMarca
    {
        public ModeloMarca()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdModeloMarca { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
