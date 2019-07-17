namespace HigoApi.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Partido { get; set; }
        public string Localidad { get; set; }
        public string PathImagenRegistro { get; set; }
    }
}