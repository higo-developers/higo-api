using HigoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HigoApi.Services.Impl
{
    public class NotificacionService : INotificacionService
    {
        private readonly HigoContext higoContext;

        public NotificacionService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public void Crear(int idUsuario, int idOperacion, string descripcion, string mensaje)
        {
            Notificacion nuevaNot = new Notificacion()
            {
                IdOperacion = idOperacion,
                IdUsuario = idUsuario,
                Mensaje = mensaje,
                Descripcion = descripcion,
                Leida = false
            };

            higoContext.Notificacion.Add(nuevaNot);
            higoContext.SaveChanges();


        }

        public void Modificar(int idNotificacion)
        {
            Notificacion notif = ObtenerPorId(idNotificacion);

            notif.Leida = true;

            higoContext.Notificacion.Update(notif);
            higoContext.SaveChanges();

        }

        public List<Notificacion> ObtenerListado(int idUsuario)
        {
            List<Notificacion> nots = (from Notificacion n in higoContext.Notificacion
                                       where n.IdUsuario == idUsuario
                                       where n.Leida == false
                                       orderby n.FechaCreacion descending
                                       select n)
                                  .ToList();

            return nots;
        }

        public Notificacion ObtenerPorId(int idNotificacion)
        {
            Notificacion notif = higoContext.Notificacion
                                    .Include(o => o.IdUsuarioNavigation)
                                    .Include(o => o.IdOperacionNavigation)
                                        .ThenInclude(v => v.IdVehiculoNavigation)
                                    .Where(o => o.IdNotificacion.Equals(idNotificacion))
                                    .FirstOrDefault();

            return notif;
        }

        public Notificacion ObtenerUltima(int idUsuario)
        {
            Notificacion notif = (from Notificacion n in higoContext.Notificacion
                                  where n.IdUsuario == idUsuario
                                  select n)
                                  .FirstOrDefault();

            return notif;
        }

        
    }
}
