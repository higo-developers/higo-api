using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdOperacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Leida { get; set; }
        public string Descripcion { get; set; }
        public string Mensaje { get; set; }
        public string Url { get; set; }

        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
