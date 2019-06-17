using System.Collections.Generic;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IVehiculoService
    {
        List<VehiculoDTO> Listar(ParametrosBusquedaVehiculo parametros);
        VehiculoDTO ObtenerPorId(int id);
    }
}