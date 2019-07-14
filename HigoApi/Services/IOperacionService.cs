using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IOperacionService
    {
        List<Operacion> ListadoPendientesPrestador(int idUsuario);

        List<Operacion> ListadoTodasPorAdquiriente(int idUsuario);

        List<Operacion> ListadoFiltradoPorEstadoPorAdquiriente(int idUsuario, string codEstado);

        Operacion Crear(OperacionDTO operacion);

        /// <summary>
        /// Actualiza según el código de estado.
        /// Estados: PENDIENTE, APROBADO, RECHAZADO, CANCELADO, COMENZADO, FINALIZADO
        /// </summary>
        /// <param name="idOperacion"></param>
        /// <param name="codEstado"></param>
        /// <returns></returns>
        Operacion Actualizar(int idOperacion, string codEstado);

        Operacion ObtenerPorId(int idOperacion);

        /// <summary>
        /// Listado de todas las operaciones de un usuario, ya sea como adquiriente o prestador.
        /// </summary>
        /// <param name="idUsuario">Id de usuario participante de la operación.</param>
        /// <returns>Listado de operaciones en las que el usuario participa.</returns>
        List<Operacion> ListadoOperacionesDeUsuario(int idUsuario);

        void ActualizarMontoEfectivo(Operacion operacion, decimal montoEfectivo);
    }
}
