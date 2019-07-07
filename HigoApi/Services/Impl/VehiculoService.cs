using System.Collections.Generic;
using System.Linq;
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
        private readonly OperacionUtils operacionUtils;
        private readonly VehiculoUtils vehiculoUtils;
        private readonly IEstadoService estadoService;

        const string ModeloMarcaNavigationPropertyPath = "IdModeloMarcaNavigation.IdMarcaNavigation";

        public VehiculoService(HigoContext higoContext, OperacionUtils operacionUtils, VehiculoUtils vehiculoUtils,
            IEstadoService estadoService)
        {
            this.higoContext = higoContext;
            this.operacionUtils = operacionUtils;
            this.vehiculoUtils = vehiculoUtils;
            this.estadoService = estadoService;
        }

        public List<Vehiculo> Listar(ParametrosBusquedaVehiculo parametros)
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
                .Include(v => v.IdEstadoVehiculoNavigation)
                .Where(v => !idsVehiculosEnOperacion.Contains(v.IdVehiculo))
                .Where(v => EstadoVehiculo.ACTIVO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Pais, parametros.Pais))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Provincia, parametros.Provincia))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Partido, parametros.Partido))
                .Where(v => vehiculoUtils.MatchLocationIfPresent(v.IdLocacionNavigation.Localidad, parametros.Localidad))
                .OrderBy(v => v.IdVehiculo)
                .ToList();

            return vehiculos;
        }

        public Vehiculo ObtenerPorId(int id)
        {
            Vehiculo vehiculo = higoContext.Vehiculo
                .Where(v => v.IdVehiculo.Equals(id))
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdCilindradaNavigation)
                .Include(v => v.IdLocacionNavigation)
                .Include(v => v.IdPrestadorNavigation)
                .Include(v => v.IdEstadoVehiculoNavigation)
                .FirstOrDefault();

            return vehiculo;
        }

        public List<Vehiculo> ListarPorIdUsuario(int idUsuario)
        {
            return higoContext.Vehiculo
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdCilindradaNavigation)
                .Include(v => v.IdLocacionNavigation)
                .Include(v => v.IdEstadoVehiculoNavigation)
                .Include(v => v.IdEstadoVehiculoNavigation)
                .Where(v => v.IdPrestador.Equals(idUsuario))
                .Where(v => !EstadoVehiculo.ELIMINADO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                .OrderBy(v => v.IdVehiculo)
                .ToList();
        }

        public Vehiculo ObtenerPorIdParaPerfil(int id)
        {
            return higoContext.Vehiculo
                .Include(v => v.IdCombustibleNavigation)
                .Include(v => v.IdModeloMarcaNavigation)
                .Include(v => v.IdEstadoVehiculoNavigation)
                .Where(v => !EstadoVehiculo.ELIMINADO.ToString().Equals(v.IdEstadoVehiculoNavigation.Codigo))
                .FirstOrDefault(v => v.IdVehiculo.Equals(id));
        }

        public Vehiculo Crear(Vehiculo vehiculo, int idUsuario)
        {
            // TODO Cambiar datos de locacion de vehiculo
            vehiculo.IdPrestador = idUsuario;

            higoContext.Vehiculo.Add(vehiculo);
            higoContext.SaveChanges();

            return ObtenerPorIdParaPerfil(vehiculo.IdVehiculo);
        }

        public Vehiculo Actualizar(Vehiculo vehiculo, int idUsuario)
        {
            // TODO Cambiar datos de locacion de vehiculo 
            vehiculo.IdPrestador = idUsuario;

            higoContext.Vehiculo.Update(vehiculo);
            higoContext.SaveChanges();

            return ObtenerPorIdParaPerfil(vehiculo.IdVehiculo);
        }

        public void Eliminar(int idVehiculo)
        {
            var vehiculo = ObtenerPorId(idVehiculo);
            
            vehiculo.IdEstadoVehiculo = estadoService.EstadoVehiculoPorCodigo(EstadoVehiculo.ELIMINADO.ToString()).IdEstadoVehiculo;
            
            higoContext.Vehiculo.Update(vehiculo);
            higoContext.SaveChanges();
        }
    }
}