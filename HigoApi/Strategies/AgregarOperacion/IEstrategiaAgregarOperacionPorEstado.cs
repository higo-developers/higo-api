using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public interface IEstrategiaAgregarOperacionPorEstado
    {
        void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operacion, RolOperacion rol);
    }
}