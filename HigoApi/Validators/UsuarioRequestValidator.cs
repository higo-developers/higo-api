using HigoApi.Models;
using HigoApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Validators
{
    public class UsuarioRequestValidator
    {
        public Usuario ValidateNullsParameter(Usuario usr, RegistrarUsuarioDTO usuarioEdited)
        {
            usr.Nombre = usuarioEdited.Nombre != null ? usuarioEdited.Nombre : usr.Nombre;
            usr.Apellido = usuarioEdited.Apellido != null ? usuarioEdited.Apellido : usr.Apellido;
            usr.Dni = usuarioEdited.Dni != null ? int.Parse(usuarioEdited.Dni) : usr.Dni;
            usr.Email = usuarioEdited.Email != null ? usuarioEdited.Email : usr.Email;
            usr.Password = usuarioEdited.Password != null ? usuarioEdited.Password : usr.Password;
            usr.Telefono = usuarioEdited.Telefono != null ? usuarioEdited.Telefono : usr.Telefono;

            return usr;
        }

        public void IsValidatedUser(RegistrarUsuarioDTO usr)
        {
            if (usr.Nombre == null || usr.Nombre == "")
                throw new ValidationException("El Nombre es obligatorio");
            if (usr.Apellido == null || usr.Apellido == "")
                throw new ValidationException("El Apellido es obligatorio");
            if (usr.Dni == null || usr.Dni == "")
                throw new ValidationException("El Dni es obligatorio");
            if (usr.Email == null || usr.Email == "")
                throw new ValidationException("El Email es obligatorio");
            if (usr.Password == null || usr.Password == "")
                throw new ValidationException("El Password es obligatorio");
        }
    }
}
