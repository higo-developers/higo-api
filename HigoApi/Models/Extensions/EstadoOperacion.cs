namespace HigoApi.Models
{
    public partial class EstadoOperacion
    {
        /// <summary>
        /// Constantes con los estados
        /// </summary>
        public const string PENDIENTE = "PENDIENTE";
        public const string APROBADO = "APROBADO";
        public const string RECHAZADO = "RECHAZADO";
        public const string CANCELADO = "CANCELADO";
        public const string CONTROL_INICIAL = "CONTROL_INICIAL";
        public const string VIGENTE = "VIGENTE";
        public const string CONTROL_FINAL = "CONTROL_FINAL";
        public const string PAGO_PENDIENTE = "PAGO_PENDIENTE";
        public const string CONFIRMACION_PAGO = "CONFIRMACION_PAGO";
        public const string FINALIZADO = "FINALIZADO";
        public const string CALIFICADO = "CALIFICADO";
    }
}