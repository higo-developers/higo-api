using System.Collections.Generic;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IVehiculoService
    {
        List<VehiculoResponse> Listar(ParametrosBusquedaVehiculo parametrosBusqueda);
    }
}