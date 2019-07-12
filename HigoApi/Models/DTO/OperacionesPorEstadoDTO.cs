using System.Collections.Generic;

namespace HigoApi.Models.DTO
{
    public class OperacionesPorEstadoDTO
    {
        public List<OperacionDTO> Pendientes { get; set; }
        public List<OperacionDTO> EnCurso { get; set; }
        public List<OperacionDTO> Finalizadas { get; set; }
    }
}