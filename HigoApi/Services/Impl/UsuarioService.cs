using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Validators;
using Microsoft.EntityFrameworkCore;
using Perfil = HigoApi.Enums.Perfil;

namespace HigoApi.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HigoContext higoContext;
        private readonly UsuarioRequestValidator validator;
        private readonly IOpcionesService opcionesService;

        public UsuarioService(HigoContext higoContext, UsuarioRequestValidator validator,
            IOpcionesService opcionesService)
        {
            this.higoContext = higoContext;
            this.validator = validator;
            this.opcionesService = opcionesService;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            if (higoContext.Usuario.Any(x => x.Email == usuario.Email))
                throw new ValidationException("El E-mail ya se encuentra registrado anteriormente");

            if (higoContext.Usuario.Any(x => x.Dni.Equals(usuario.Dni)))
                throw new ValidationException("El DNI ya se encuentra registrado anteriormente");

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
            if (higoContext.Usuario.Any(x => x.Email == usuarioARegistrar.Email))
                throw new ValidationException("El E-mail ya se encuentra registrado anteriormente");

            if (higoContext.Usuario.Any(x => x.Dni.Equals(long.Parse(usuarioARegistrar.Dni))))
                throw new ValidationException("El DNI ya se encuentra registrado anteriormente");

            validator.IsValidatedUser(usuarioARegistrar);
            var usr = new Usuario
            {
                Nombre = usuarioARegistrar.Nombre,
                Apellido = usuarioARegistrar.Apellido,
                Dni = int.Parse(usuarioARegistrar.Dni),
                Email = usuarioARegistrar.Email,
                Password = usuarioARegistrar.Password,
                IdPerfil = opcionesService.PerfilPorCodigo(Perfil.USER.ToString()).IdPerfil,
                FechaAlta = DateTime.Now
            };
            higoContext.Usuario.Add(usr);
            higoContext.SaveChanges();

            return usr;
        }

        public Usuario UsuarioPorEmailYOrigen(string email, OrigenUsuario origen)
        {
            return higoContext.Usuario.FirstOrDefault(u => u.Email.Equals(email) && u.Origen.Equals(origen.ToString()));
        }
    }
}
