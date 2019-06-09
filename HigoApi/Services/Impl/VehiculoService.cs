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
            List<Vehiculo> query = (from Operacion o in higoContext.Operacion
                         join Vehiculo v in higoContext.Vehiculo on o.IdVehiculo equals v.IdVehiculo
                         join Usuario u in higoContext.Usuario on v.IdPrestador equals u.IdUsuario
                         join Locacion l in higoContext.Locacion on u.IdLocacion equals l.IdLocacion
//                         where parametrosBusqueda.FechaDesde >= o.FechaHoraDesde
//                         where parametrosBusqueda.FechaHasta <= o.FechaHoraHasta
//                         where parametrosBusqueda.Latitud == l.Latitud
//                         where parametrosBusqueda.Longitud == l.Longitud
                         select v).ToList();
            
            return vehiculoMapper.ToVehiculoResponseList(query);
        }
    }
}