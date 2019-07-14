using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Builders
{
    public class ControlResponseBuilder
    {
        public ControlResponse Build(Control control, Operacion operacion)
        {
            return new ControlResponse
            {
                IdControl = control.IdControl,
                IdOperacion = operacion.IdOperacion,
                EstadoOperacion = operacion.IdEstadoOperacionNavigation.Descripcion,
                CodigoEstadoOperacion = operacion.IdEstadoOperacionNavigation.Codigo
            };
        }
    }
}