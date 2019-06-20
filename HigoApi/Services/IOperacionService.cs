using HigoApi.Models;
using HigoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Services
{
    public interface IOperacionService
    {
        List<Operacion> ListadoPendientesPrestador(int idUsuario);

        List<Operacion> ListadoTodasPorAdquiriente(int idUsuario);

        List<Operacion> ListadoFiltradoPorEstadoPorAdquiriente(int idUsuario, string codEstado);

        Operacion Crear(OperacionDTO operacion);

        Operacion Actualizar(int idOperacion, string codEstado);

        Operacion ObtenerPorId(int idOperacion);
        
    }
}
