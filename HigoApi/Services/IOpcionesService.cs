using System.Collections.Generic;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IOpcionesService
    {
        List<Cilindrada> ListarCilindradas();
        List<Combustible> ListarCombustibles();
    }
}