using System;
using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class TipoService : ITipoService
    {
        private readonly HigoContext higoContext;

        private const string TipoVehiculoInvalidoErrorMessage = "Tipo de vehículo inválido";

        public TipoService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public TipoVehiculo ObtenerPorCodigo(string codigo)
        {
            var tipoVehiculo = higoContext.TipoVehiculo.FirstOrDefault(t => t.Codigo.Equals(codigo));

            if (tipoVehiculo == null)
                throw new FormatException(TipoVehiculoInvalidoErrorMessage);

            return tipoVehiculo;
        }
    }
}