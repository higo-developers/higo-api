using HigoApi.Builders;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionEnCurso : IEstrategiaAgregarOperacionPorEstado
    {
        private readonly OperacionDTOBuilder operacionDtoBuilder;

        public AgregarOperacionEnCurso(OperacionDTOBuilder operacionDtoBuilder)
        {
            this.operacionDtoBuilder = operacionDtoBuilder;
        }

        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operacion, RolOperacion rol)
        {
            dto.EnCurso.Add(operacionDtoBuilder.Build(operacion, rol));
        }
    }
}