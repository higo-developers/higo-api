using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class TipoService : ITipoService
    {
        private readonly HigoContext higoContext;

        public TipoService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public TipoVehiculo ObtenerPorCodigo(string codigo)
        {
            return higoContext.TipoVehiculo.FirstOrDefault(t => t.Codigo.Equals(codigo));
        }
    }
}