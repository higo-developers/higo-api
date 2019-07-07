﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HigoApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Operacion = new HashSet<Operacion>();
            Vehiculo = new HashSet<Vehiculo>();
            Notificacion = new HashSet<Notificacion>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long? Dni { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdLocacion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }

        [MaxLength(30)]
        public string Origen { get; set; }

        public virtual Locacion IdLocacionNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
        public virtual ICollection<Notificacion> Notificacion { get; set; }
    }
}
