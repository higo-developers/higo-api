using System;
using HigoApi.Models;

namespace HigoApi.Utils
{
    public class OperacionUtils
    {
        public bool BetweenDateTimes(Operacion operacion, DateTime fechaDesde, DateTime fechaHasta)
        {
            var rangoBusquedaEntreRangoOperacion =
                operacion.FechaHoraDesde <= fechaDesde && fechaDesde <= operacion.FechaHoraHasta
                || operacion.FechaHoraDesde <= fechaHasta && fechaHasta <= operacion.FechaHoraHasta;

            var rangoOperacionEntreRangoBusqueda =
                fechaDesde <= operacion.FechaHoraHasta && operacion.FechaHoraHasta <= fechaHasta
                || fechaDesde <= operacion.FechaHoraDesde && operacion.FechaHoraHasta <= fechaHasta;

            return rangoBusquedaEntreRangoOperacion || rangoOperacionEntreRangoBusqueda;
        }
    }
}