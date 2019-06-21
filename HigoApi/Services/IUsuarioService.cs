using HigoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Services
{
    public interface IUsuarioService
    {
        Usuario ObtenerUsuarioPorId(int id);
        void ActualizarUsuario(Usuario usuario);
    }
}
