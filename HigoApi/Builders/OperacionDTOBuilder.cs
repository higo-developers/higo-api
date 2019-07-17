using HigoApi.Enums;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Services;

namespace HigoApi.Builders
{
    public class OperacionDTOBuilder
    {
        private readonly IWorkflowService workflowService;
        private readonly OperacionWorkflowMapper operacionWorkflowMapper;

        public OperacionDTOBuilder(IWorkflowService workflowService, OperacionWorkflowMapper operacionWorkflowMapper)
        {
            this.workflowService = workflowService;
            this.operacionWorkflowMapper = operacionWorkflowMapper;
        }

        public OperacionDTO Build(Operacion operacion, RolOperacion rol)
        {
            var operacionDto = OperacionMapper.ConvertirAOperacionDTO(operacion);
            
            operacionDto.ProximosEstados = operacionWorkflowMapper.ToWorkflowDtoList(
                workflowService.ProximosEstadosPorCodigoYRol(operacion.IdEstadoOperacionNavigation.Codigo, rol)
            );

            return operacionDto;
        }
    }
}