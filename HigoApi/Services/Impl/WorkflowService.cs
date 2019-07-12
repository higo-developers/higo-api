using System.Collections.Generic;
using System.Linq;
using HigoApi.Enums;
using HigoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class WorkflowService : IWorkflowService
    {
        private readonly HigoContext higoContext;

        public WorkflowService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public List<OperacionWorkflow> ProximosEstadosPorCodigoYRol(string codigoEstadoActual, RolOperacion rol)
        {
            return higoContext.OperacionWorkflow
                .Include(ow => ow.IdEstadoActualNavigation)
                .Include(ow => ow.IdProximoEstadoNavigation)
                .Where(ow => ow.IdEstadoActualNavigation.Codigo.Equals(codigoEstadoActual))
                .Where(ow => ow.Rol.Equals(rol.ToString()))
                .ToList();
        }

        public List<EstadoOperacion> ProximosEstadosPorCodigo(string codigoEstado)
        {
            return higoContext.OperacionWorkflow
                .Include(ow => ow.IdEstadoActualNavigation)
                .Include(ow => ow.IdProximoEstadoNavigation)
                .Where(ow => ow.IdEstadoActualNavigation.Codigo.Equals(codigoEstado))
                .Select(ow => ow.IdProximoEstadoNavigation)
                .ToList();
        }
    }
}