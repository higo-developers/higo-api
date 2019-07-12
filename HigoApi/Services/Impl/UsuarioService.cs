using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Validators;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HigoContext higoContext;
        private readonly UsuarioRequestValidator validator;

        public UsuarioService(HigoContext higoContext, UsuarioRequestValidator validator)
        {
            this.higoContext = higoContext;
            this.validator = validator;
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
            return higoContext.Usuario.FirstOrDefault(u => u.IdUsuario.Equals(id));
        }

        public Usuario RegistrarUsuario(RegistrarUsuarioDTO usuarioARegistrar)
        {
            var origen = usuarioARegistrar.Origen.HasValue ? usuarioARegistrar.Origen.ToString() : OrigenUsuario.PORTAL.ToString();
            
            if (higoContext.Usuario.Any(x => x.Email.Equals(usuarioARegistrar.Email) && x.Origen.Equals(origen)))
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
                FechaAlta = DateTime.Now,
                IdPerfil = 2, // TODO Revisar por qué carga el objeto PerfilNavigation al obtener id consultando Perfil por código.
                Origen = origen,
                Telefono = usuarioARegistrar.Telefono,
                
                Latitud = usuarioARegistrar.Locacion?.Latitud,
                Longitud = usuarioARegistrar.Locacion?.Longitud,
                Pais = usuarioARegistrar.Locacion?.Pais,
                Provincia = usuarioARegistrar.Locacion?.Provincia,
                Partido = usuarioARegistrar.Locacion?.Partido,
                Localidad = usuarioARegistrar.Locacion?.Localidad
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
