using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Control
    {
        public int IdControl { get; set; }
        public int? IdOperacion { get; set; }
        public int IdTipoControl { get; set; }
        public DateTime? FechaHoraControl { get; set; }
        public long? Km { get; set; }

        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual TipoControl IdTipoControlNavigation { get; set; }
    }
}
