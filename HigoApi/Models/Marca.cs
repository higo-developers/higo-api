using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Marca
    {
        public Marca()
        {
            ModeloMarca = new HashSet<ModeloMarca>();
        }

        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ModeloMarca> ModeloMarca { get; set; }
    }
}
