using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Utils;

namespace HigoApi.Mappers
{
    public class VehiculoMapper
    {
        private readonly LocacionMapper locacionMapper;
        private readonly UsuarioMapper usuarioMapper;
        private readonly VehiculoUtils vehiculoUtils;

        public VehiculoMapper(LocacionMapper locacionMapper, UsuarioMapper usuarioMapper, VehiculoUtils vehiculoUtils)
        {
            this.locacionMapper = locacionMapper;
            this.usuarioMapper = usuarioMapper;
            this.vehiculoUtils = vehiculoUtils;
        }

        public List<VehiculoDTO> ToVehiculoDTOList(List<Vehiculo> vehiculos)
        {
            return vehiculos.ConvertAll(vehiculo => ToVehiculoDTO(vehiculo));
        }

        public VehiculoDTO ToVehiculoDTO(Vehiculo vehiculo)
        {
            var response = new VehiculoDTO
            {
                Id = vehiculo.IdVehiculo,
                Equipamiento = vehiculoUtils.EquipamientoAsList(vehiculo)
            };


            if (vehiculo.IdCilindradaNavigation != null)
                response.Cilindrada = vehiculo.IdCilindradaNavigation.Descripcion;

            if (vehiculo.IdModeloMarcaNavigation != null)
            {
                response.Modelo = vehiculo.IdModeloMarcaNavigation.Descripcion;
                if (vehiculo.IdModeloMarcaNavigation.IdMarcaNavigation != null)
                    response.Marca = vehiculo.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion;
            }

            if (vehiculo.IdLocacionNavigation != null)
                response.Locacion = locacionMapper.ToLocacionDTO(vehiculo.IdLocacionNavigation);

            if (vehiculo.IdPrestadorNavigation != null)
                response.Usuario = usuarioMapper.ToUsuarioDTO(vehiculo.IdPrestadorNavigation);

            return response;
        }
    }
}