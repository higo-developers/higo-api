using System;

namespace HigoApi.Models.DTO
{
    public class ParametrosBusquedaVehiculo
    {
        public Nullable<DateTime> FechaDesde { get; set; }
        public Nullable<DateTime> FechaHasta { get; set; }
        public Nullable<int> Localidad { get; set; }
    }
}