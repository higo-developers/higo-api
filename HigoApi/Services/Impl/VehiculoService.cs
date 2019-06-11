using System.Collections.Generic;
using System.Linq;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class VehiculoService : IVehiculoService
    {
        private readonly HigoContext higoContext;
        private readonly VehiculoMapper vehiculoMapper;

        const string ModeloMarcaNavigationPropertyPath = "IdModeloMarcaNavigation.IdMarcaNavigation";

        public VehiculoService(HigoContext higoContext, VehiculoMapper vehiculoMapper)
        {
            this.higoContext = higoContext;
            this.vehiculoMapper = vehiculoMapper;
        }

        public List<VehiculoResponse> Listar(ParametrosBusquedaVehiculo parametros)
        {
            /* Se obtienen los IDs de vehículos en operación entre el rango de fecha de los parámetros de búsqueda */
            ISet<int> idsVehiculosEnOperacion = higoContext.Operacion
                .Where(o => OperacionUtils.BetweenDateTimes(o, parametros.FechaDesdeAsDateTime(), parametros.FechaHastaAsDateTime()))
                .Select(o => o.IdVehiculo)
                .ToHashSet();

            List<Vehiculo> vehiculos = higoContext.Vehiculo
                .Where(v => !idsVehiculosEnOperacion.Contains(v.IdVehiculo))
                .Include(v => v.IdCilindradaNavigation)
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdLocacionNavigation)
                .ToList();

            return vehiculoMapper.ToVehiculoResponseList(vehiculos);
        }
    }
}