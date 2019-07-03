using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface INotificacionService
    {
        Notificacion ObtenerUltima(int idUsuario);

        List<Notificacion> ObtenerListado(int idUsuario);

        void Crear(int idUsuario, Operacion operacion);
        void Modificar(int idNotificacion);

        Notificacion ObtenerPorId(int idNotificacion);
    }
}
