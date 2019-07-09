using System;
using System.Collections.Generic;

namespace HigoApi.Models.DTO
{
    public class OperacionDTO
    {
        public int IdOperacion { get; set; }
        public int IdAdquiriente { get; set; }
        public int IdVehiculo { get; set; }
        public string CodEstado { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }
        public string Prestador { get; set; }
        public string Adquirente { get; set; }
        public string Vehiculo { get; set; }
        public decimal? MontoAcordado { get; set; }
        public decimal? MontoEfectivo { get; set; }

        public List<WorkflowDTO> ProximosEstados { get; set; }
    }
}