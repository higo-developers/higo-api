using System.Collections.Generic;
using System.Linq;
using HigoApi.Models;

namespace HigoApi.Services.Impl
{
    public class MarcaService : IMarcaService
    {
        private readonly HigoContext higoContext;

        public MarcaService(HigoContext higoContext)
        {
            this.higoContext = higoContext;
        }

        public List<Marca> Listar()
        {
            return higoContext.Marca.OrderBy(marca => marca.IdMarca).ToList();
        }

        public Marca ObtenerPorId(int id)
        {
            return higoContext.Marca.FirstOrDefault(marca => marca.IdMarca.Equals(id));
        }

        public List<ModeloMarca> ListarModelosDeMarca(int idMarca)
        {
            return higoContext.ModeloMarca.OrderBy(modelo => modelo.IdModeloMarca)
                .Where(modelo => modelo.IdMarca.Equals(idMarca))
                .ToList();
        }
    }
}