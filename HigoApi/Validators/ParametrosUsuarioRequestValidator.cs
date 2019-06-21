using HigoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Validators
{
    public class ParametrosUsuarioRequestValidator
    {
        public Usuario ValidateNullsParameter(Usuario usr, Usuario usuarioEdited)
        {
            usr.Nombre = usuarioEdited.Nombre != null ? usuarioEdited.Nombre : usr.Nombre;
            usr.Apellido = usuarioEdited.Apellido != null ? usuarioEdited.Apellido : usr.Apellido;
            usr.Dni = usuarioEdited.Dni != null ? usuarioEdited.Dni : usr.Dni;
            usr.IdPerfil = usuarioEdited.IdPerfil != null ? usuarioEdited.IdPerfil : usr.IdPerfil;
            usr.IdLocacion = usuarioEdited.IdLocacion != null ? usuarioEdited.IdLocacion : usr.IdLocacion;
            usr.FechaAlta = usuarioEdited.FechaAlta != null ? usuarioEdited.FechaAlta : usr.FechaAlta;
            usr.Email = usuarioEdited.Email != null ? usuarioEdited.Email : usr.Email;
            usr.Password = usuarioEdited.Password != null ? usuarioEdited.Password : usr.Password;
            usr.Telefono = usuarioEdited.Telefono != null ? usuarioEdited.Telefono : usr.Telefono;

            return usr;
        }
    }
}
