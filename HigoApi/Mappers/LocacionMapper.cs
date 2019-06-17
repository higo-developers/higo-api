using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class LocacionMapper
    {
        public LocacionResponse ToLocacionResponse(Locacion locacion)
        {
            return new LocacionResponse
            {
                Latitud = locacion.Latitud,
                Longitud = locacion.Longitud,
                Pais = locacion.Pais,
                Provincia = locacion.Provincia,
                Localidad = locacion.Localidad
            };
        }
    }
}