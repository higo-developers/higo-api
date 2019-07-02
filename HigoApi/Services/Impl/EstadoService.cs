using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class EstadoService : IEstadoService
    {
        private readonly HigoContext higoContext;

        public EstadoService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public EstadoVehiculo EstadoVehiculoPorCodigo(string codigo)
        {
            return higoContext.EstadoVehiculo.FirstOrDefault(ev => ev.Codigo.Equals(codigo));
        }
    }
}