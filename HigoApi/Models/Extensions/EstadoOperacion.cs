using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models
{
    public partial class EstadoOperacion
    {
        /// <summary>
        /// Constantes con los estados
        /// </summary>
        public const string PENDIENTE = "PENDIENTE";
        public const string RECHAZADO = "RECHAZADO";
        public const string APROBADO = "APROBADO";
        public const string CANCELADO = "CANCELADO";
        public const string EJECUCION = "EJECUCION";
        public const string FINALIZADO = "FINALIZADO";
    }
}
