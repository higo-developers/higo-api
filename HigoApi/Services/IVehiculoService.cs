using System.Collections.Generic;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    interface IVehiculoService
    {
        List<VehiculoResponse> Listar();
    }
}
