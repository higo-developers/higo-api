using System.ComponentModel.DataAnnotations;
using System.Linq;
using HigoApi.Models;
using HigoApi.Services;

namespace HigoApi.Validators
{
    public class CambioEstadoOperacionValidator
    {
        const string MessageCambioEstadoInvalido =
            "Cambio de estado no permitido. Estado actual de operación {0}: {1}.";

        private readonly IWorkflowService workflowService;

        public CambioEstadoOperacionValidator(IWorkflowService workflowService)
        {
            this.workflowService = workflowService;
        }

        public void Validar(Operacion operacion, string codigoEstadoOperacion)
        {
            var proximosEstados = workflowService.ProximosEstadosPorCodigo(operacion.IdEstadoOperacionNavigation.Codigo)
                .Select(eo => eo.Codigo)
                .ToList();

            if (!proximosEstados.Contains(codigoEstadoOperacion))
                throw new ValidationException(string.Format(
                    MessageCambioEstadoInvalido,
                    operacion.IdOperacion,
                    operacion.IdEstadoOperacionNavigation.Descripcion)
                );
        }
    }
}