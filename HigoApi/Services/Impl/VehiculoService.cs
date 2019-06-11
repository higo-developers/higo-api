using System.Collections.Generic;
using System.Linq;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
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
            List<Vehiculo> query = higoContext.Vehiculo
                .Include(v => v.IdCilindradaNavigation)
                .Include(ModeloMarcaNavigationPropertyPath)
                .Include(v => v.IdLocacionNavigation)
                .ToList();

            return vehiculoMapper.ToVehiculoResponseList(query);
        }
    }
}