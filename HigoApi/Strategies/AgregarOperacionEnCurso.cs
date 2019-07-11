using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionEnCurso : IEstrategiaAgregarOperacionPorEstado
    {
        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operaciones, RolOperacion rol)
        {
            dto.EnCurso.Add(new OperacionDTO());
        }
    }
}