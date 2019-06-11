using HigoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Services
{
    public interface IOperacionService
    {
        List<Operacion> ListadoPendientesPrestador(int idUsuario);

        List<Operacion> ListadoRealizadasPorAdquiriente(int idUsuario);

        Operacion Crear(Operacion operacion);

        Operacion Aprobar(int idOperacion);

        Operacion Rechazar(int idOperacion);

        Operacion Cancelar(int idOperacion);

        Operacion Comenzar(int idOperacion);

        Operacion Finalizar(int idOperacion);

        Operacion ObtenerPorId(int idOperacion);
        
    }
}
