using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IEstadoService
    {
        EstadoVehiculo EstadoVehiculoPorCodigo(string codigo);
    }
}