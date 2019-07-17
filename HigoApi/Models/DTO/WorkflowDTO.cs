namespace HigoApi.Models.DTO
{
    public class WorkflowDTO
    {
        /// <summary>
        /// Código de próximo estado.
        /// </summary>
        public string ProximoEstado { get; set; }

        /// <summary>
        /// Descripción de acción a realizar.
        /// </summary>
        public string DescripcionAccion { get; set; }
    }
}