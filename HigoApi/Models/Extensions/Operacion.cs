using HigoApi.Models.DTO;

namespace HigoApi.Models
{
    public partial class Operacion
    {
        public Operacion(OperacionDTO opDTO)
        {
            FechaHoraDesde = opDTO.FechaHoraDesde;
            FechaHoraHasta = opDTO.FechaHoraHasta;
            IdAdquirente = opDTO.IdAdquiriente;
        }
    }
}