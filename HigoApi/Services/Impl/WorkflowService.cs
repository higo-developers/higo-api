using System.Collections.Generic;
using System.Linq;
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

        public List<OperacionWorkflow> ProximosEstados(string codigoEstadoActual)
        {
            return higoContext.OperacionWorkflow
                .Include(ow => ow.IdEstadoActualNavigation)
                .Include(ow => ow.IdProximoEstadoNavigation)
                .Where(ow => ow.IdEstadoActualNavigation.Codigo.Equals(codigoEstadoActual))
                .ToList();
        }
    }
}