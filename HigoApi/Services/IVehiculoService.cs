using HigoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Services
{
    interface IVehiculoService
    {
        public List<VehiculoResponse> Listar();
    }
}
