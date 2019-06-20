using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Builders
{
    public class LoginResponseBuilder
    {
        private readonly TokenBuilder tokenBuilder;
        private readonly UsuarioMapper usuarioMapper;

        public LoginResponseBuilder(TokenBuilder tokenBuilder, UsuarioMapper usuarioMapper)
        {
            this.tokenBuilder = tokenBuilder;
            this.usuarioMapper = usuarioMapper;
        }

        public LoginResponse Build(Usuario usuario)
        {
            var tokenDto = tokenBuilder.Build(usuario.Email);

            return new LoginResponse
            {
                Token = tokenDto.Token,
                FechaExpiracion = tokenDto.Expiration,
                DatosUsuario = usuarioMapper.ToDatosUsuarioLogin(usuario)
            };
        }
    }
}