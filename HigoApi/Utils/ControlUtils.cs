using HigoApi.Models;

namespace HigoApi.Utils
{
    public class ControlUtils
    {
        private const decimal PorcentajeControlIncumplido = 0.05m;

        public decimal CalcularMontoEfectivo(Control control, decimal montoAcordado)
        {
            var porcentajeAdicional = 1.0m;

            if (control.NivelCombustibleFinal.GetValueOrDefault() < control.NivelCombustibleInicial.GetValueOrDefault())
                porcentajeAdicional += PorcentajeControlIncumplido;

            if (control.HigieneExternaFinal.GetValueOrDefault() < control.HigieneExternaInicial.GetValueOrDefault())
                porcentajeAdicional += PorcentajeControlIncumplido;

            if (control.HigieneInternaFinal.GetValueOrDefault() < control.HigieneInternaInicial.GetValueOrDefault())
                porcentajeAdicional += PorcentajeControlIncumplido;

            if (control.FuncionamientoGeneralFinal.GetValueOrDefault() < control.FuncionamientoGeneralInicial.GetValueOrDefault())
                porcentajeAdicional += PorcentajeControlIncumplido;

            return montoAcordado * porcentajeAdicional;
        }
    }
}