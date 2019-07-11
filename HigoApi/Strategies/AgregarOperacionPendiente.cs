using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionPendiente : IEstrategiaAgregarOperacionPorEstado
    {
        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operaciones, RolOperacion rol)
        {
            dto.Pendientes.Add(new OperacionDTO());
        }
    }
}