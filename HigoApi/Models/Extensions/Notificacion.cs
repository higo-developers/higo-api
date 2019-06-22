using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models
{
    public partial class Notificacion
    {
        public Notificacion()
        {
            FechaCreacion = DateTime.Now;
        }

        public Notificacion(int idUsuario, int idOperacion)
        {
            IdOperacion = idOperacion;
            IdUsuario = idUsuario;
            FechaCreacion = DateTime.Now;
        }

        public Notificacion(int idUsuario, int idOperacion, string descripcion, string mensaje)
        {
            IdOperacion = idOperacion;
            IdUsuario = idUsuario;
            Descripcion = descripcion;
            Mensaje = mensaje;
            FechaCreacion = DateTime.Now;
        }
    }
}
