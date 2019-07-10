using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Builders
{
    public class OperacionesClasificadasDTOBuilder
    {
        /// <summary>
        /// Construcción de operaciones de usuario clasificandolas por rol (ADQUIRENTE o PRESTADOR)
        /// </summary>
        /// <param name="operaciones"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public OperacionesClasificadasDTO Build(List<Operacion> operaciones, int idUsuario)
        {
            var operacionesClasificadasDto = new OperacionesClasificadasDTO();

            return operacionesClasificadasDto;
        }
    }
}