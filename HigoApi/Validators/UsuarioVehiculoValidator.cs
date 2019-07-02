using System.ComponentModel.DataAnnotations;
using System.Linq;
using HigoApi.Models;

namespace HigoApi.Validators
{
    public class UsuarioVehiculoValidator
    {
        private readonly HigoContext higoContext;

        private static readonly string ErrorMessage = "El vehículo {0} no le pertenece a usuario {1}";

        public UsuarioVehiculoValidator(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public void Validate(int usuarioId, int vehiculoId)
        {
            var exists = higoContext.Vehiculo.FirstOrDefault(v => v.IdVehiculo.Equals(vehiculoId) && v.IdPrestador.Equals(usuarioId));

            if (exists == null)
                throw new ValidationException(string.Format(ErrorMessage, vehiculoId, usuarioId));
        }
    }
}