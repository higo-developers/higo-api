using System.Collections.Generic;
using System.Linq;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Strategies;

namespace HigoApi.Builders
{
    public class OperacionesClasificadasDTOBuilder
    {
        private Dictionary<string, IEstrategiaAgregarOperacionPorEstado> estrategiaAddOperacion;

        public OperacionesClasificadasDTOBuilder(AgregarOperacionPendiente agregarOperacionPendiente,
            AgregarOperacionEnCurso agregarOperacionEnCurso, AgregarOperacionFinalizada agregarOperacionFinalizada)
        {
            estrategiaAddOperacion = new Dictionary<string, IEstrategiaAgregarOperacionPorEstado>();
            estrategiaAddOperacion.Add(EstadoOperacion.PENDIENTE, agregarOperacionPendiente);
            estrategiaAddOperacion.Add(EstadoOperacion.APROBADO, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.VIGENTE, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.CONTROL_INICIAL, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.CONTROL_FINAL, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.PAGO_PENDIENTE, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.CONFIRMACION_PAGO, agregarOperacionEnCurso);
            estrategiaAddOperacion.Add(EstadoOperacion.FINALIZADO, agregarOperacionFinalizada);
            estrategiaAddOperacion.Add(EstadoOperacion.CANCELADO, agregarOperacionFinalizada);
            estrategiaAddOperacion.Add(EstadoOperacion.RECHAZADO, agregarOperacionFinalizada);
            estrategiaAddOperacion.Add(EstadoOperacion.CALIFICADO, agregarOperacionFinalizada);
        }

        /// <summary>
        /// Construcción de operaciones de usuario clasificandolas por rol (ADQUIRENTE o PRESTADOR)
        /// </summary>
        /// <param name="operaciones">Lista de operaciones en las que participa un usuario, ya sea como prestador o adquirente.</param>
        /// <param name="idUsuario">Id de usuario que participa en las operaciones.</param>
        /// <returns>DTO con las operaciones clasificadas por rol (ADQUIRENTE y/o PRESTADOR) y por estado (PENDIENTES, EN CURSO y FINALIZADAS).</returns>
        public OperacionesClasificadasDTO Build(List<Operacion> operaciones, int idUsuario)
        {
            var operacionesClasificadasDto = new OperacionesClasificadasDTO();

            var operacionesAdquirente = new List<Operacion>();
            var operacionesPrestador = new List<Operacion>();

            operaciones.ForEach(o =>
            {
                if
                    (o.IdAdquirente.Equals(idUsuario)) operacionesAdquirente.Add(o);
                else
                    operacionesPrestador.Add(o);
            });

            operacionesClasificadasDto.Adquirente = operacionesAdquirente.Any()
                ? SetOperacionesPorEstado(operacionesAdquirente, RolOperacion.ADQUIRENTE)
                : null;

            operacionesClasificadasDto.Prestador = operacionesPrestador.Any()
                ? SetOperacionesPorEstado(operacionesPrestador, RolOperacion.PRESTADOR)
                : null;

            return operacionesClasificadasDto;
        }

        private OperacionesPorEstadoDTO SetOperacionesPorEstado(List<Operacion> operaciones, RolOperacion rol)
        {
            var porEstadoDto = new OperacionesPorEstadoDTO
            {
                Pendientes = new List<OperacionDTO>(),
                EnCurso = new List<OperacionDTO>(),
                Finalizadas = new List<OperacionDTO>()
            };

            operaciones.ForEach(o =>
                estrategiaAddOperacion
                    .GetValueOrDefault(o.IdEstadoOperacionNavigation.Codigo)
                    .AgregarOperacion(porEstadoDto, o, rol)
            );

            return porEstadoDto;
        }
    }
}