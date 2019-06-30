using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Validators;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HigoContext higoContext;
        private readonly ParametrosUsuarioRequestValidator validator;

        public UsuarioService(HigoContext higoContext,ParametrosUsuarioRequestValidator validator)
        {
            this.higoContext = higoContext;
            this.validator = validator;
        }

        public void ActualizarUsuario(Usuario usuario)
        {

            higoContext.Entry(usuario).State = EntityState.Modified;
            higoContext.SaveChanges();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            var usuario = higoContext.Usuario.Where(u => u.IdUsuario == id).FirstOrDefault();
            return usuario;
        }

        public Usuario RegistrarUsuario(RegistrarUsuarioDTO usuarioARegistrar)
        {
            if ((validator.IsValidatedUser(usuarioARegistrar)))
            {
                Usuario usr = new Usuario()
                {
                    Nombre = usuarioARegistrar.Nombre,
                    Apellido = usuarioARegistrar.Apellido,
                    Dni = usuarioARegistrar.Dni,
                    Email = usuarioARegistrar.Email,
                    Password = usuarioARegistrar.Password,
                    IdPerfil = 2
                    
                };
                higoContext.Usuario.Add(usr);
                higoContext.SaveChanges();

                return usr;
            }

            return null;
        }
    }
}
