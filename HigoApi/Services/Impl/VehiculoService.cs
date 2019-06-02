using System.Collections.Generic;
using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class VehiculoService : IVehiculoService
    {
        private readonly HigoContext higoContext;

        public VehiculoService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public List<Vehiculo> Listar()
        {
            return higoContext.Vehiculo.ToList();
        }
    }
}
