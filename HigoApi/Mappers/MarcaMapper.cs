using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class MarcaMapper
    {
        public List<MarcaDTO> ToMarcaDTOList(List<Marca> marcas)
        {
            return marcas.ConvertAll(marca => ToMarcaDto(marca));
        }

        public MarcaDTO ToMarcaDto(Marca marca)
        {
            return new MarcaDTO {Id = marca.IdMarca, Descripcion = marca.Descripcion};
        }
    }
}