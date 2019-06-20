using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly IOperacionService _operacionService;

        public OperacionesController(IOperacionService operacionService)
        {
            this._operacionService = operacionService;
        }

        [HttpGet]
        [Consumes("application/json")]
        //public IEnumerable<Operacion> Get([FromBody] OperacionDTO opRes)
        public IEnumerable<OperacionDTO> Get()
        {
            List<Operacion> operaciones = new List<Operacion>();
            /*
            if (opRes.CodEstado != null)
            {
                operaciones = _operacionService.ListadoFiltradoPorEstadoPorAdquiriente(opRes.IdAdquiriente, opRes.CodEstado);
            }
            else
            {
                operaciones = _operacionService.ListadoTodasPorAdquiriente(opRes.IdAdquiriente);
            }
            */

            operaciones = _operacionService.ListadoTodasPorAdquiriente(1);


            return OperacionMapper.ConvertirAOperacionDTOLista(operaciones);
        }

        // GET: api/Operacion/5
        [HttpGet("{id}", Name = "Get")]
        public OperacionDTO Get(int id)
        {
            Operacion op = _operacionService.ObtenerPorId(id);

            OperacionDTO opDTO = OperacionMapper.ConvertirAOperacionDTO(op);

            return opDTO;
        }


        // POST: api/Default
        [HttpPost]
        public OperacionDTO Post([FromBody] OperacionDTO opRes)
        {
            Operacion op = _operacionService.Crear(opRes);

            return OperacionMapper.ConvertirAOperacionDTO(op);
        }

        // PUT: api/Operaciones/5
        [HttpPut]
        public OperacionDTO Put(OperacionDTO opRes)
        {
            Operacion op = _operacionService.Actualizar(opRes.IdOperacion, opRes.CodEstado);

            return OperacionMapper.ConvertirAOperacionDTO(op);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
