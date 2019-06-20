using System;

namespace HigoApi.Models.DTO
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public DatosUsuarioLoginDTO DatosUsuario { get; set; }
    }
}