﻿using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IVehiculoService
    {
        List<Vehiculo> Listar(ParametrosBusquedaVehiculo parametros);
        Vehiculo ObtenerPorId(int id);
        List<Vehiculo> ListarPorIdUsuario(int idUsuario);
        Vehiculo ObtenerPorIdParaPerfil(int id);
        Vehiculo Crear(Vehiculo vehiculo, int idUsuario);
        Vehiculo Actualizar(Vehiculo vehiculo, int idUsuario);
        void Eliminar(int idVehiculo);
    }
}