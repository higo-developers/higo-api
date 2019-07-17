using System.Collections.Generic;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IMarcaService
    {
        List<Marca> Listar();
        Marca ObtenerPorId(int id);
        List<ModeloMarca> ListarModelosDeMarca(int idMarca);
    }
}