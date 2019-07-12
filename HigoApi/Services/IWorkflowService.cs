using System.Collections.Generic;
using HigoApi.Enums;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IWorkflowService
    {
        /// <summary>
        /// Obtención de próximos estados posibles en base a estado actual de operación y el rol de quien ejecutaría un cambio de estado.
        /// </summary>
        /// <param name="codigoEstadoActual">Código de estado actual.</param>
        /// <param name="rol">Rol del usuario que ejecutará la acción.</param>
        /// <returns>Listado de próximos estados posibles.</returns>
        List<OperacionWorkflow> ProximosEstadosPorCodigoYRol(string codigoEstadoActual, RolOperacion rol);

        /// <summary>
        /// Obtención de próximos estados posibles en base a un código de estado.
        /// </summary>
        /// <param name="codigoEstado">Código de estado del cual se quieren listar los próximos estados posibles.</param>
        /// <returns>Listado de próximos estados posibles.</returns>
        List<EstadoOperacion> ProximosEstadosPorCodigo(string codigoEstado);
    }
}