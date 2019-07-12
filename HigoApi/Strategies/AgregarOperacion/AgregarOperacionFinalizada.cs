using HigoApi.Builders;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionFinalizada : IEstrategiaAgregarOperacionPorEstado
    {
        private readonly OperacionDTOBuilder operacionDtoBuilder;

        public AgregarOperacionFinalizada(OperacionDTOBuilder operacionDtoBuilder)
        {
            this.operacionDtoBuilder = operacionDtoBuilder;
        }

        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operacion, RolOperacion rol)
        {
            dto.Finalizadas.Add(operacionDtoBuilder.Build(operacion, rol));
        }
    }
}