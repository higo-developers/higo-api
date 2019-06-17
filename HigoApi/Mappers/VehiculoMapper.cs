using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class VehiculoMapper
    {
        private readonly LocacionMapper locacionMapper;
        private readonly UsuarioMapper usuarioMapper;

        public VehiculoMapper(LocacionMapper locacionMapper, UsuarioMapper usuarioMapper)
        {
            this.locacionMapper = locacionMapper;
            this.usuarioMapper = usuarioMapper;
        }

        public List<VehiculoResponse> ToVehiculoResponseList(List<Vehiculo> vehiculos)
        {
            return vehiculos.ConvertAll(vehiculo => ToVehiculoResponse(vehiculo));
        }

        public VehiculoResponse ToVehiculoResponse(Vehiculo vehiculo)
        {
            var response = new VehiculoResponse
            {
                Id = vehiculo.IdVehiculo
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
                response.Locacion = locacionMapper.ToLocacionResponse(vehiculo.IdLocacionNavigation);

            if (vehiculo.IdPrestadorNavigation != null)
                response.Usuario = usuarioMapper.ToUsuarioResponse(vehiculo.IdPrestadorNavigation);


            return response;
        }
    }
}