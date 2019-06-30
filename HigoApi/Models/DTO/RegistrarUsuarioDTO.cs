using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models.DTO
{
    public class RegistrarUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Telefono { get; set; }
    }
}
