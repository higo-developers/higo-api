using HigoApi.Enums;

namespace HigoApi.Models.DTO
{
    public class RegistrarUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }

        public OrigenUsuario? Origen { get; set; }

        public LocacionDTO Locacion { get; set; }
    }
}
