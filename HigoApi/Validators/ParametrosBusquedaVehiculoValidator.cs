using System;
using System.ComponentModel.DataAnnotations;
using HigoApi.Models.DTO;

namespace HigoApi.Validators
{
    public class ParametrosBusquedaVehiculoValidator
    {
        private const string MessageParametroAusente = "Parámetro requerido ausente";
        private const string MessageErrorFechas = "Error en fechas enviadas";

        public void Validate(ParametrosBusquedaVehiculo parametros)
        {
            if (string.IsNullOrWhiteSpace(parametros.FechaDesde)
                || string.IsNullOrWhiteSpace(parametros.FechaHasta))
            {
                throw new ValidationException(MessageParametroAusente);
            }

            if (DateTime.Compare(parametros.GetFechaDesdeAsDateTime(), parametros.GetFechaHastaAsDateTime()) > 0)
            {
                throw new FormatException(MessageErrorFechas);
            }
        }
    }
}