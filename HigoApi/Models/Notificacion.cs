using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string URL { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Operacion IdOperacionNavigation { get; set; }
    }
}
