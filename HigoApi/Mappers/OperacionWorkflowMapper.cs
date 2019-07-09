using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class OperacionWorkflowMapper
    {
        public List<WorkflowDTO> ToWorkflowDtoList(List<OperacionWorkflow> workflows)
        {
            return workflows.ConvertAll(ow => ToWorkflowDto(ow));
        }

        private WorkflowDTO ToWorkflowDto(OperacionWorkflow ow)
        {
            return new WorkflowDTO
            {
                DescripcionAccion = ow.DescripcionAccion,
                ProximoEstado = ow.IdProximoEstadoNavigation.Codigo
            };
        }
    }
}