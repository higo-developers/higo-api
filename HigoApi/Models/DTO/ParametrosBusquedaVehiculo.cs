using System;

namespace HigoApi.Models.DTO
{
    public class ParametrosBusquedaVehiculo
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }

        public DateTime GetFechaDesdeAsDateTime()
        {
            return string.IsNullOrEmpty(FechaDesde) ? DateTime.Now : DateTime.Parse(FechaDesde);
        }

        public DateTime GetFechaHastaAsDateTime()
        {
            return string.IsNullOrEmpty(FechaHasta) ? DateTime.Now : DateTime.Parse(FechaHasta);
        }
        
    }
}