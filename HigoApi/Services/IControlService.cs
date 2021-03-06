using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IControlService
    {
        Control ObtenerPorId(int idControl);
        Control ObtenerControlPorIdDeOperacion(int idOperacion);
        ControlDTO ObtenerControlDtoPorIdOperacion(int idOperacion);
        ControlResponse Crear(ControlDTO controlDto);
        ControlResponse Actualizar(ControlDTO controlDto);
    }
}