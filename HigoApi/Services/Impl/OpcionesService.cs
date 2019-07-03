using System;
using System.Collections.Generic;
using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class OpcionesService : IOpcionesService
    {
        private readonly HigoContext higoContext;
        
        private const string CodigoCombustibleInvalidoErrorMessage = "Código de combustible inválido";

        public OpcionesService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public List<Cilindrada> ListarCilindradas()
        {
            return higoContext.Cilindrada.OrderBy(c => c.IdCilindrada).ToList();
        }

        public List<Combustible> ListarCombustibles()
        {
            return higoContext.Combustible.OrderBy(c => c.IdCombustible).ToList();
        }

        public Combustible CombustiblePorCodigo(string codigo)
        {
            var combustible = higoContext.Combustible.FirstOrDefault(v => v.Codigo.Equals(codigo));

            if (combustible == null)
                throw new FormatException(CodigoCombustibleInvalidoErrorMessage);

            return combustible;
        }
    }
}