using System.ComponentModel.DataAnnotations;
using System.Linq;
using HigoApi.Models;
using HigoApi.Services;

namespace HigoApi.Validators
{
    public class CambioEstadoOperacionValidator
    {
        const string MessageCambioEstadoInvalido = "Cambio de estado no permitido";

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

            if (proximosEstados.Any() && !proximosEstados.Contains(codigoEstadoOperacion))
                throw new ValidationException(MessageCambioEstadoInvalido);
        }
    }
}