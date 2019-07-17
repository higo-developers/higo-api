using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class OpcionesMapper
    {
        public List<CilindradaDTO> CilindradasToDTOList(List<Cilindrada> cilindradas)
        {
            return cilindradas.ConvertAll(CilindradaToDTO);
        }
        
        public List<CombustibleDTO> CombustiblesToDTOList(List<Combustible> combustibles)
        {
            return combustibles.ConvertAll(CombustibleToDTO);
        }
        
        public CilindradaDTO CilindradaToDTO(Cilindrada cilindrada)
        {
            return new CilindradaDTO {Id = cilindrada.IdCilindrada, Descripcion = cilindrada.Descripcion};
        }

        public CombustibleDTO CombustibleToDTO(Combustible combustible)
        {
            return new CombustibleDTO
            {
                Id = combustible.IdCombustible,
                Descripcion = combustible.Descripcion,
                Codigo = combustible.Codigo
            };
        }
    }
}