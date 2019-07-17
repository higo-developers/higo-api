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
                Nombre = $"{usuario.Nombre} {usuario.Apellido}",
                Email = usuario.Email,
                Dni = usuario.Dni.ToString(),
                Telefono = usuario.Telefono,
                Pais = usuario.Pais,
                Provincia = usuario.Provincia,
                Partido = usuario.Partido,
                Localidad = usuario.Localidad,
                PathImagenRegistro = usuario.PathImagenRegistro
            };
        }

        public DatosUsuarioLoginDTO ToDatosUsuarioLogin(Usuario usuario)
        {
            return new DatosUsuarioLoginDTO
            {
                Id = usuario.IdUsuario,
                Username = $"{usuario.Nombre} {usuario.Apellido}",
                Rol = usuario.IdPerfilNavigation.Codigo
            };
        }
    }
}