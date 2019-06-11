using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class OperacionService : IOperacionService
    {
        private readonly HigoContext higoContext;

        public OperacionService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public Operacion Crear(Operacion dataOperacion)
        {
            Operacion nuevaOperacion = new Operacion(dataOperacion);

            higoContext.Operacion.Add(nuevaOperacion);
            higoContext.SaveChanges();

            return nuevaOperacion;
        }

        public Operacion Aprobar(int idOperacion)
        {

            throw new NotImplementedException();
        }

        public Operacion Rechazar(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public Operacion Cancelar(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public Operacion Comenzar(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public Operacion Finalizar(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public List<Operacion> ListadoPendientesPrestador(int idUsuario)
        {
            List<Operacion> operaciones = (from Operacion o in higoContext.Operacion
                                           where o.IdVehiculoNavigation.IdPrestador == idUsuario
                                           where o.IdEstadoOperacionNavigation.Descripcion == "Pendiente"
                                           select o).ToList();

            return operaciones;
        }

        public List<Operacion> ListadoRealizadasPorAdquiriente(int idUsuario)
        {
            List<Operacion> operaciones = (from Operacion o in higoContext.Operacion
                                           where o.IdAdquirente == idUsuario
                                           orderby o.FechaHoraDesde ascending
                                           select o).ToList();

            throw new NotImplementedException();
        }

        public Operacion ObtenerPorId(int idOperacion)
        {
            Operacion op = (from Operacion o in higoContext.Operacion
                            where o.IdOperacion == idOperacion
                            select o)
                            .FirstOrDefault();
            return op;
        }
    }
}
