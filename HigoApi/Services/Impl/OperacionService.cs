using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class OperacionService : IOperacionService
    {
        private readonly HigoContext higoContext;
        private readonly INotificacionService notificacionService;

        public OperacionService(HigoContext higoContext, INotificacionService notificacionService)
        {
            this.higoContext = higoContext;
            this.notificacionService = notificacionService;
        }

        public Operacion Crear(OperacionDTO dataOp)
        {
            Operacion nuevaOperacion = new Operacion(dataOp);

            higoContext.Operacion.Add(nuevaOperacion);
            higoContext.SaveChanges();

            Operacion opRes = ObtenerPorId(nuevaOperacion.IdOperacion);

            notificacionService.Crear(opRes.IdVehiculoNavigation.IdPrestador.GetValueOrDefault(),
                                        opRes.IdOperacion,
                                        "Nueva solicitud",
                                        opRes.IdAdquirenteNavigation.Nombre + " solicita tu " +
                                        opRes.IdVehiculoNavigation.IdModeloMarcaNavigation.Descripcion);

            return opRes;
        }

        /// <summary>
        /// Actualiza según el código de estado.
        /// Estados: PENDIENTE, APROBADO, RECHAZADO, CANCELADO, COMENZADO, FINALIZADO
        /// </summary>
        /// <param name="idOperacion"></param>
        /// <param name="codEstado"></param>
        /// <returns></returns>
        public Operacion Actualizar(int idOperacion, string codEstado)
        {
            EstadoOperacion estadoOp = ObtenerEstadoOperacionPorCodigo(codEstado);

            Operacion op = ObtenerPorId(idOperacion);
            op.IdEstadoOperacion = estadoOp.IdEstadoOperacion;

            higoContext.Operacion.Update(op);
            higoContext.SaveChanges();

            switch (codEstado)
            {
                case "APROBADO":
                case "RECHAZADO":
                    notificacionService.Crear(op.IdAdquirente,
                                        op.IdOperacion,
                                        "Pedido " + codEstado.ToLower(),
                                        "El prestador ha " + codEstado.ToLower() + " tu solicitud");
                    break;
                case "CANCELADO":
                case "FINALIZADO":
                    notificacionService.Crear(op.IdVehiculoNavigation.IdPrestador.GetValueOrDefault(),
                                        op.IdOperacion,
                                        "Pedido " + codEstado.ToLower(),
                                        op.IdAdquirenteNavigation.Nombre + " ha " + codEstado.ToLower() + " el pedido");
                    break;
                default:
                    break;
            }
            

            return op;
        }

        public List<Operacion> ListadoPendientesPrestador(int idUsuario)
        {
            List<Operacion> operaciones = (from Operacion o in higoContext.Operacion
                                           where o.IdVehiculoNavigation.IdPrestador == idUsuario
                                           where o.IdEstadoOperacionNavigation.Codigo == "PENDIENTE"
                                           select o).ToList();

            return operaciones;
        }

        public List<Operacion> ListadoTodasPorAdquiriente(int idUsuario)
        {
            List<Operacion> operaciones = higoContext.Operacion
                .Include(o => o.IdEstadoOperacionNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdPrestadorNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdModeloMarcaNavigation)
                        .ThenInclude(m => m.IdMarcaNavigation)
                .Where(o => o.IdAdquirente.Equals(idUsuario))
                .ToList();

            return operaciones;
        }


        public Operacion ObtenerPorId(int idOperacion)
        {
            Operacion op = higoContext.Operacion
                .Include(o => o.IdEstadoOperacionNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdPrestadorNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdModeloMarcaNavigation)
                        .ThenInclude(m => m.IdMarcaNavigation)
                .Include(o => o.IdAdquirenteNavigation)
                .Where(o => o.IdOperacion.Equals(idOperacion))
                .FirstOrDefault();

            return op;
        }

        private EstadoOperacion ObtenerEstadoOperacionPorCodigo(string cod)
        {
            EstadoOperacion estadoOp = (from EstadoOperacion eo in higoContext.EstadoOperacion
                                        where eo.Codigo == cod
                                        select eo)
                                        .FirstOrDefault();

            return estadoOp;
        }

        public List<Operacion> ListadoFiltradoPorEstadoPorAdquiriente(int idUsuario, string codEstado)
        {
            List<Operacion> operaciones = higoContext.Operacion
                .Include(o => o.IdEstadoOperacionNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdPrestadorNavigation)
                .Include(o => o.IdVehiculoNavigation)
                    .ThenInclude(v => v.IdModeloMarcaNavigation)
                        .ThenInclude(m => m.IdMarcaNavigation)
                .Where(o => o.IdAdquirente.Equals(idUsuario))
                .Where(o => o.IdEstadoOperacionNavigation.Codigo.Equals(codEstado))
                .ToList();

            return operaciones;
        }
    }
}
