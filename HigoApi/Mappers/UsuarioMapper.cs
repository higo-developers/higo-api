using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class UsuarioMapper
    {
        public UsuarioResponse ToUsuarioResponse(Usuario usuario)
        {
            return new UsuarioResponse
            {
                Id = usuario.IdUsuario,
                Nombre = $"{usuario.Nombre} {usuario.Apellido}"
            };
        }
    }
}