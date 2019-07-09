﻿using System.Collections.Generic;
using System.Linq;
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

            notificacionService.Crear(opRes.IdVehiculoNavigation.IdPrestador.GetValueOrDefault(), opRes);

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
                case EstadoOperacion.APROBADO:
                case EstadoOperacion.RECHAZADO:
                    notificacionService.Crear(op.IdAdquirente, op);
                    break;
                case EstadoOperacion.CANCELADO:
                case EstadoOperacion.PENDIENTE:
                    notificacionService.Crear(op.IdVehiculoNavigation.IdPrestador.GetValueOrDefault(), op);
                    break;
                case EstadoOperacion.EJECUCION:
                case EstadoOperacion.FINALIZADO:
                    notificacionService.Crear(op.IdAdquirente, op);
                    notificacionService.Crear(op.IdVehiculoNavigation.IdPrestador.GetValueOrDefault(), op);
                    break;
            }
            

            return op;
        }

        public List<Operacion> ListadoPendientesPrestador(int idUsuario)
        {
            List<Operacion> operaciones = (from Operacion o in higoContext.Operacion
                                           where o.IdVehiculoNavigation.IdPrestador == idUsuario
                                           where o.IdEstadoOperacionNavigation.Codigo == EstadoOperacion.PENDIENTE
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
                .Include(o => o.IdAdquirenteNavigation)
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
                .FirstOrDefault(o => o.IdOperacion.Equals(idOperacion));

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
                .Include(o => o.IdAdquirenteNavigation)
                .Where(o => o.IdAdquirente.Equals(idUsuario))
                .Where(o => o.IdEstadoOperacionNavigation.Codigo.Equals(codEstado))
                .ToList();

            return operaciones;
        }
        
        public List<Operacion> ListadoOperacionesDeUsuario(int idUsuario)
        {
            return higoContext.Operacion.Where(o => o.IdAdquirente.Equals(idUsuario) || o.IdVehiculoNavigation.IdPrestador.Equals(idUsuario))
                .Include(o => o.IdEstadoOperacionNavigation)
                .Include(o => o.IdVehiculoNavigation)
                .ThenInclude(v => v.IdPrestadorNavigation)
                .Include(o => o.IdVehiculoNavigation)
                .ThenInclude(v => v.IdModeloMarcaNavigation)
                .ThenInclude(m => m.IdMarcaNavigation)
                .Include(o => o.IdAdquirenteNavigation)
                .ToList();
        }
    }
}
