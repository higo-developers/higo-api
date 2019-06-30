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
                Equipamiento = vehiculoUtils.EquipamientoAsList(vehiculo),
                Estado = vehiculo.IdEstadoVehiculoNavigation.Codigo
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

        public PerfilVehiculoDTO ToPerfilVehiculoDTO(Vehiculo vehiculo)
        {
            var perfilVehiculoDto = new PerfilVehiculoDTO();

            perfilVehiculoDto.Id = vehiculo.IdVehiculo;
            perfilVehiculoDto.Anno = vehiculo.Anno?.ToString();
            perfilVehiculoDto.Patente = vehiculo.Patente;
            perfilVehiculoDto.Combustible = vehiculo.IdCombustibleNavigation.Codigo;
            perfilVehiculoDto.Modelo = vehiculo.IdModeloMarca;
            perfilVehiculoDto.Cilindrada = vehiculo.IdCilindrada;

            perfilVehiculoDto.Ac = vehiculo.Ac ?? false;
            perfilVehiculoDto.Da = vehiculo.Da ?? false;
            perfilVehiculoDto.Dh = vehiculo.Dh ?? false;
            perfilVehiculoDto.Alarma = vehiculo.Alarma ?? false;
            perfilVehiculoDto.CierreCentralizado = vehiculo.CierreCentralizado ?? false;
            perfilVehiculoDto.RompenieblasDelantero = vehiculo.RompenieblasDelantero ?? false;
            perfilVehiculoDto.RompenieblasTrasero = vehiculo.RompenieblasTrasero ?? false;
            perfilVehiculoDto.Airbag = vehiculo.Airbag ?? false;
            perfilVehiculoDto.Abs = vehiculo.Abs ?? false;
            perfilVehiculoDto.ControlTraccion = vehiculo.ControlTraccion ?? false;
            perfilVehiculoDto.TapizadoCuero = vehiculo.TapizadoCuero ?? false;

            return perfilVehiculoDto;
        }
    }
}