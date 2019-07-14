using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IControlService
    {
        Control ObtenerControlPorIdDeOperacion(int idOperacion);
        Control Crear(ControlDTO controlDto);
        Control Actualizar(ControlDTO controlDto);
    }
}