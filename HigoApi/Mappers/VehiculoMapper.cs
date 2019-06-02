﻿using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class VehiculoMapper
    {
        public List<VehiculoResponse> ToVehiculoResponseList(List<Vehiculo> vehiculos)
        {
            return vehiculos.ConvertAll(vehiculo => ToVehiculoResponse(vehiculo));
        }

        private static VehiculoResponse ToVehiculoResponse(Vehiculo vehiculo)
        {
            return new VehiculoResponse
            {
                Cilindrada = vehiculo.IdCilindradaNavigation.Descripcion,
                Marca = vehiculo.IdModeloMarcaNavigation.IdMarcaNavigation.Descripcion,
                Modelo = vehiculo.IdModeloMarcaNavigation.Descripcion
            };
        }
    }
}