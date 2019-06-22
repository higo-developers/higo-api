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

        void Crear(int idUsuario, int idOperacion, string descripcion, string mensaje);
        void Modificar(int idNotificacion);

        Notificacion ObtenerPorId(int idNotificacion);
    }
}
