using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Notificacion = new HashSet<Notificacion>();
            Operacion = new HashSet<Operacion>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long? Dni { get; set; }
        public int? IdPerfil { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Origen { get; set; }
        public string Latitud { get; set; }
        public string Localidad { get; set; }
        public string Longitud { get; set; }
        public string Pais { get; set; }
        public string Partido { get; set; }
        public string Provincia { get; set; }
        public string PathImagenRegistro { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Notificacion> Notificacion { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
