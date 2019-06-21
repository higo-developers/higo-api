using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HigoContext higoContext;

        public UsuarioService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
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
    }
}
