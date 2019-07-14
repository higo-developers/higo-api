using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HigoApi.Factories;
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
        private const string RouteIdOperacionControl = "{id}/control";
        private const string RouteIdOperacionControlId = "{id}/control/{idControl}";
        
        private readonly IOperacionService _operacionService;
        
        private readonly ErrorResponseFactory errorResponseFactory;

        public OperacionesController(IOperacionService operacionService, ErrorResponseFactory errorResponseFactory)
        {
            _operacionService = operacionService;
            this.errorResponseFactory = errorResponseFactory;
        }

        [HttpGet]
        [Consumes("application/json")]
        // GET: api/Operacion
        public IEnumerable<OperacionDTO> Get([FromBody] OperacionDTO opDTO)
        {
            List<Operacion> operaciones = new List<Operacion>();
            
            if (opDTO.CodEstado != null)
            {
                operaciones = _operacionService.ListadoFiltradoPorEstadoPorAdquiriente(opDTO.IdAdquiriente, opDTO.CodEstado);
            }
            else
            {
                operaciones = _operacionService.ListadoTodasPorAdquiriente(opDTO.IdAdquiriente);
            }
            

            //operaciones = _operacionService.ListadoTodasPorAdquiriente(opDTO.IdAdquiriente);


            return OperacionMapper.ConvertirAOperacionDTOLista(operaciones);
        }

        // GET: api/Operacion/5
        [HttpGet("{id}", Name = "GetOperacion")]
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
        public IActionResult Put(OperacionDTO opRes)
        {
            try
            {
                Operacion op = _operacionService.Actualizar(opRes.IdOperacion, opRes.CodEstado);
                return Ok(OperacionMapper.ConvertirAOperacionDTO(op));
            }
            catch (ValidationException ve)
            {
                return UnprocessableEntity(new ErrorResponse(StatusCodes.Status422UnprocessableEntity, ve.Message));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost(RouteIdOperacionControl)]
        public IActionResult PostControlOperacion(int id)
        {
            try
            {
                return Ok(new {Mensaje = $"Crear control para operacion {id}"});
            }
            catch (ValidationException ve)
            {
                return UnprocessableEntity(new ErrorResponse(StatusCodes.Status422UnprocessableEntity, ve.Message));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        [HttpPut(RouteIdOperacionControlId)]
        public IActionResult PostControlOperacion(int id, int idControl)
        {
            try
            {
                return Ok(new {Mensaje = $"Actualizar control {idControl} de operacion {id}"});
            }
            catch (ValidationException ve)
            {
                return UnprocessableEntity(new ErrorResponse(StatusCodes.Status422UnprocessableEntity, ve.Message));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }
    }
}
