using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Services;
using HigoApi.Utils;
using TipoVehiculo = HigoApi.Enums.TipoVehiculo;

namespace HigoApi.Mappers
{
    public class VehiculoMapper
    {
        private readonly LocacionMapper locacionMapper;
        private readonly UsuarioMapper usuarioMapper;
        private readonly VehiculoUtils vehiculoUtils;

        private readonly ITipoService tipoService;
        private readonly IOpcionesService opcionesService;

        public VehiculoMapper(LocacionMapper locacionMapper, UsuarioMapper usuarioMapper, VehiculoUtils vehiculoUtils,
            ITipoService tipoService, IOpcionesService opcionesService)
        {
            this.locacionMapper = locacionMapper;
            this.usuarioMapper = usuarioMapper;
            this.vehiculoUtils = vehiculoUtils;
            this.tipoService = tipoService;
            this.opcionesService = opcionesService;
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
            perfilVehiculoDto.Marca = vehiculo.IdModeloMarcaNavigation.IdMarca;
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

        public Vehiculo FromPerfilVehiculoDTO(PerfilVehiculoDTO dto)
        {
            var vehiculo = new Vehiculo(dto);
            vehiculo.IdTipoVehiculo = tipoService.ObtenerPorCodigo(TipoVehiculo.AUTO.ToString()).IdTipoVehiculo;
            vehiculo.IdCombustible = opcionesService.CombustiblePorCodigo(dto.Combustible).IdCombustible;
            return vehiculo;
        }
    }
}