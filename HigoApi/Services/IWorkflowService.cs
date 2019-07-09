using System.Collections.Generic;
using HigoApi.Enums;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IWorkflowService
    {
        /// <summary>
        /// Obtención de próximos estados posibles en base a estado actual de operación.
        /// </summary>
        /// <param name="codigoEstadoActual">Código de estado actual.</param>
        /// <param name="rol">Rol del usuario que ejecutará la acción.</param>
        /// <returns>Listado de próximos estados posibles.</returns>
        List<OperacionWorkflow> ProximosEstados(string codigoEstadoActual, RolOperacion rol);
    }
}