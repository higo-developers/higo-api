using HigoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models
{
    public partial class Operacion
    {
        public Operacion(OperacionDTO opDTO)
        {
            FechaHoraDesde = opDTO.FechaHoraDesde;
            FechaHoraHasta = opDTO.FechaHoraHasta;
            IdAdquirente = opDTO.IdAdquiriente;
            IdEstadoOperacion = 1;
            IdVehiculo = opDTO.IdVehiculo;
            MontoAcordado = opDTO.MontoAcordado;
        }
    }
}
