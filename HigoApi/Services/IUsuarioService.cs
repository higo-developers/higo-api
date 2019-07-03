using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services
{
    public interface IUsuarioService
    {
        Usuario ObtenerUsuarioPorId(int id);
        void ActualizarUsuario(Usuario usuario);
        Usuario RegistrarUsuario(RegistrarUsuarioDTO usuarioARegistrar);
    }
}
