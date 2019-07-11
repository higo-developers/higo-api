using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionFinalizada : IEstrategiaAgregarOperacionPorEstado
    {
        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operaciones, RolOperacion rol)
        {
            dto.Finalizadas.Add(new OperacionDTO());
        }
    }
}