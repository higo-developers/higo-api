using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class EstadoOperacion
    {
        public EstadoOperacion()
        {
            Operacion = new HashSet<Operacion>();
            OperacionWorkflowIdEstadoActualNavigation = new HashSet<OperacionWorkflow>();
            OperacionWorkflowIdProximoEstadoNavigation = new HashSet<OperacionWorkflow>();
        }

        public int IdEstadoOperacion { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual ICollection<OperacionWorkflow> OperacionWorkflowIdEstadoActualNavigation { get; set; }
        public virtual ICollection<OperacionWorkflow> OperacionWorkflowIdProximoEstadoNavigation { get; set; }
    }
}
