using System.Collections.Generic;
using System.Linq;
using HigoApi.Models;
using HigoApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class NotificacionService : INotificacionService
    {
        private readonly HigoContext higoContext;

        public NotificacionService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        private const string UrlAdquiriente = "/API/Adquiriente/";
        private const string UrlPrestador = "/API/Prestador/";

        public void Crear(int idUsuario, Operacion operacion)
        {
            Notificacion nuevaNot = new Notificacion()
            {
                IdOperacion = operacion.IdOperacion,
                IdUsuario = idUsuario,
                Mensaje = ObtenerMensajePorEstado(operacion),
                Descripcion = ObtenerDescripcionPorEstado(operacion),
                Url = ObtenerURLPorEstado(operacion),
                Leida = false
            };

            higoContext.Notificacion.Add(nuevaNot);
            higoContext.SaveChanges();

            switch (operacion.IdEstadoOperacionNavigation.Codigo)
            {
                case EstadoOperacion.PENDIENTE:
                    EmailUtil.EmailNuevaSolicitud(operacion);
                    break;
                case EstadoOperacion.APROBADO:
                    EmailUtil.EmailAprobarSolicitud(operacion);
                    break;
                case EstadoOperacion.CANCELADO:
                    EmailUtil.EmailCancelarSolicitud(operacion);
                    break;
                case EstadoOperacion.FINALIZADO:
                    EmailUtil.EmailFinalizarSolicitud(operacion, idUsuario);
                    break;
                case EstadoOperacion.RECHAZADO:
                    EmailUtil.EmailRechazarSolicitud(operacion);
                    break;
                case EstadoOperacion.VIGENTE:
                    EmailUtil.EmailComenzarSolicitud(operacion, idUsuario);
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Unicamente cambia el estado del campo Leída.
        /// </summary>
        /// <param name="idNotificacion"></param>
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

        private string ObtenerDescripcionPorEstado(Operacion operacion)
        {
            string descripcion = string.Empty;
            string codEstado = operacion.IdEstadoOperacionNavigation.Codigo;

            switch (codEstado)
            {
                case EstadoOperacion.PENDIENTE:
                    descripcion = "Nuevo pedido";
                    break;
                case EstadoOperacion.APROBADO:
                case EstadoOperacion.CANCELADO:
                case EstadoOperacion.FINALIZADO:
                case EstadoOperacion.RECHAZADO:
                    descripcion = "Alquiler " + codEstado.ToLower();
                    break;
                case EstadoOperacion.VIGENTE:
                    descripcion = "El alquiler ha comenzado!";
                    break;
                default:
                    break;
            }
            return descripcion;
        }
        private string ObtenerMensajePorEstado(Operacion operacion)
        {
            string mensaje = string.Empty;

            switch (operacion.IdEstadoOperacionNavigation.Codigo)
            {
                case EstadoOperacion.PENDIENTE:
                    mensaje = operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
                    mensaje += " ha solicitado tu vehículo ";
                    mensaje += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
                    mensaje += " desde el " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraDesde.GetValueOrDefault().ToShortTimeString();
                    mensaje += " hasta el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
                    break;
                case EstadoOperacion.APROBADO:
                case EstadoOperacion.RECHAZADO:
                    mensaje = "Tu pedido de alquiler para el vehículo ";
                    mensaje += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
                    mensaje += " ha sido " + operacion.IdEstadoOperacionNavigation.Codigo.ToLower() + " por el titular.";
                    break;
                case EstadoOperacion.CANCELADO:
                    mensaje = operacion.IdAdquirenteNavigation.Nombre + " " + operacion.IdAdquirenteNavigation.Apellido;
                    mensaje += " ha cancelado el alquiler de tu vehículo ";
                    mensaje += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion + ".";
                    break;
                case EstadoOperacion.VIGENTE:
                    mensaje = "El alquiler del vehículo ";
                    mensaje += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
                    mensaje += " ha comenzado!\n";
                    mensaje += "Finaliza el " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortDateString() + " a las " + operacion.FechaHoraHasta.GetValueOrDefault().ToShortTimeString();
                    break;
                case EstadoOperacion.FINALIZADO:
                    mensaje = "El alquiler del vehículo ";
                    mensaje += operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion + " " + operacion.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion;
                    mensaje += " ha finalizado!";

                    break;
                default:
                    break;
            }

            return mensaje;
        }
        private string ObtenerURLPorEstado(Operacion operacion)
        {
            string url = string.Empty;

            switch (operacion.IdEstadoOperacionNavigation.Codigo)
            {
                case EstadoOperacion.PENDIENTE:
                case EstadoOperacion.APROBADO:
                case EstadoOperacion.CANCELADO:
                case EstadoOperacion.FINALIZADO:
                case EstadoOperacion.RECHAZADO:
                case EstadoOperacion.VIGENTE:
                    break;
                default:
                    break;
            }

            return url;
        }

        
    }
}
