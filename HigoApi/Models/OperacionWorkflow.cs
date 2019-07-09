namespace HigoApi.Models
{
    public partial class OperacionWorkflow
    {
        public int IdOperacionWorkflow { get; set; }
        public string DescripcionAccion { get; set; }
        public int IdEstadoActual { get; set; }
        public int IdProximoEstado { get; set; }

        public virtual EstadoOperacion IdEstadoActualNavigation { get; set; }
        public virtual EstadoOperacion IdProximoEstadoNavigation { get; set; }
    }
}
