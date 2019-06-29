using System.Collections.Generic;
using System.Linq;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Utils;
using Microsoft.EntityFrameworkCore;
using EstadoVehiculo = HigoApi.Enums.EstadoVehiculo;

namespace HigoApi.Services.Impl
{
    public class VehiculoService : IVehiculoService
    {
        private readonly HigoContext higoContext;
        private readonly VehiculoMapper vehiculoMapper;
        private readonly OperacionUtils operacionUtils;
        private readonly VehiculoUtils vehiculoUtils;

        const string ModeloMarcaNavigationPropertyPath = "IdModeloMarcaNavigation.IdMarcaNavigation";

        public VehiculoService(HigoContext higoContext, VehiculoMapper vehiculoMapper, OperacionUtils operacionUtils,
            VehiculoUtils vehiculoUtils)
        {
            this.higoContext = higoContext;
            this.vehiculoMapper = vehiculoMapper;
            this.operacionUtils = operacionUtils;
            this.vehiculoUtils = vehiculoUtils;
        }

        public List<VehiculoDTO> Listar(ParametrosBusquedaVehiculo parametros)
        {
            /* Se obtienen los IDs de vehículos en operación entre el rango de fecha de los parámetros de búsqueda */
            ISet<int> idsVehiculosEnOperacion = higoContext.Operacion
                .Where(o => operacionUtils.BetweenDateTimes(o, parametros.FechaDesdeAsDateTime(),
                    parametros.FechaHastaAsDateTime()))
                .Select(o => o.IdVehiculo)
                .ToHashSet();

            List<Vehiculo> vehiculos = higoContext.Vehiculo
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdCilindradaNavigation)
                .Include(v => v.IdLocacionNavigation)
                .Where(v => !idsVehiculosEnOperacion.Contains(v.IdVehiculo))
                .Where(v => EstadoVehiculo.ACTIVO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Pais, parametros.Pais))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Provincia, parametros.Provincia))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Partido, parametros.Partido))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Localidad, parametros.Localidad))
                .ToList();

            return vehiculoMapper.ToVehiculoDTOList(vehiculos);
        }

        public VehiculoDTO ObtenerPorId(int id)
        {
            Vehiculo vehiculo = higoContext.Vehiculo
                .Where(v => v.IdVehiculo.Equals(id))
                .Where(v => EstadoVehiculo.ACTIVO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdCilindradaNavigation)
                .Include(v => v.IdLocacionNavigation)
                .Include(v => v.IdPrestadorNavigation)
                .FirstOrDefault();

            return vehiculoMapper.ToVehiculoDTO(vehiculo);
        }

        public List<VehiculoDTO> ListarPorIdUsuario(int idUsuario)
        {
            return vehiculoMapper.ToVehiculoDTOList(
                higoContext.Vehiculo
                    .Where(v => v.IdPrestador.Equals(idUsuario))
                    .Where(v => EstadoVehiculo.ACTIVO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                    .Include(ModeloMarcaNavigationPropertyPath)
                    .Include(v => v.IdCilindradaNavigation)
                    .Include(v => v.IdLocacionNavigation)
                    .ToList()
            );
        }
    }
}