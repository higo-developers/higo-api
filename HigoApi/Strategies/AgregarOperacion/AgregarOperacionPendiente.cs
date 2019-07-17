using HigoApi.Builders;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Strategies
{
    public class AgregarOperacionPendiente : IEstrategiaAgregarOperacionPorEstado
    {
        private readonly OperacionDTOBuilder operacionDtoBuilder;

        public AgregarOperacionPendiente(OperacionDTOBuilder operacionDtoBuilder)
        {
            this.operacionDtoBuilder = operacionDtoBuilder;
        }

        public void AgregarOperacion(OperacionesPorEstadoDTO dto, Operacion operacion, RolOperacion rol)
        {
            dto.Pendientes.Add(operacionDtoBuilder.Build(operacion, rol));
        }
    }
}