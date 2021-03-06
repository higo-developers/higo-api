using System.Collections.Generic;
using HigoApi.Models;

namespace HigoApi.Services
{
    public interface IOpcionesService
    {
        List<Cilindrada> ListarCilindradas();
        List<Combustible> ListarCombustibles();
        Combustible CombustiblePorCodigo(string codigo);

        /* TODO Reubicar este métdodo a un service más específico. */
        Perfil PerfilPorCodigo(string codigo);
    }
}