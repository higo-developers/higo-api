using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class TipoControl
    {
        public TipoControl()
        {
            Control = new HashSet<Control>();
        }

        public int IdTipoControl { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Control> Control { get; set; }
    }
}
