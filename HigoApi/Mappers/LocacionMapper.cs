using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class LocacionMapper
    {
        public LocacionDTO ToLocacionDTO(Locacion locacion)
        {
            return new LocacionDTO
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