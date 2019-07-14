namespace HigoApi.Models.DTO
{
    public class ControlResponse
    {
        public int IdControl { get; set; }
        public int IdOperacion { get; set; }
        public string EstadoOperacion { get; set; }
        public string CodigoEstadoOperacion { get; set; }
        public string Mensaje { get; set; }
    }
}