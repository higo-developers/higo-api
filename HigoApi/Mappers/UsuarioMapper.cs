using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class UsuarioMapper
    {
        public UsuarioDTO ToUsuarioDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.IdUsuario,
                Nombre = $"{usuario.Nombre} {usuario.Apellido}"
            };
        }
    }
}