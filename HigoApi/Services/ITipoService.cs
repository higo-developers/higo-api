using HigoApi.Models;

namespace HigoApi.Services
{
    public interface ITipoService
    {
        TipoVehiculo ObtenerPorCodigo(string codigo);
    }
}