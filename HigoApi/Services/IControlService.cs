using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IControlService
    {
        Control ObtenerControlPorIdDeOperacion(int idOperacion);
        ControlResponse Crear(ControlDTO controlDto);
        ControlResponse Actualizar(ControlDTO controlDto);
    }
}