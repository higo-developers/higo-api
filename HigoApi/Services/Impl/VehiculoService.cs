using System.Collections.Generic;
using System.Linq;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services.Impl
{
    public class VehiculoService : IVehiculoService
    {
        private readonly HigoContext higoContext;
        private readonly VehiculoMapper vehiculoMapper;

        public VehiculoService(HigoContext higoContext, VehiculoMapper vehiculoMapper)
        {
            this.higoContext = higoContext;
            this.vehiculoMapper = vehiculoMapper;
        }

        public List<VehiculoResponse> Listar(ParametrosBusquedaVehiculo parametrosBusqueda)
        {
            return vehiculoMapper.ToVehiculoResponseList(higoContext.Vehiculo.ToList());
        }
    }
}