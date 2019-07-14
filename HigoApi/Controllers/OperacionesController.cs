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
        private const string RouteIdOperacionControl = "{idOperacion}/control";
        
        private readonly IOperacionService operacionService;
        private readonly IControlService controlService;
        
        private readonly ErrorResponseFactory errorResponseFactory;

        public OperacionesController(IOperacionService operacionService, IControlService controlService,
            ErrorResponseFactory errorResponseFactory)
        {
            this.operacionService = operacionService;
            this.controlService = controlService;
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
                operaciones = operacionService.ListadoFiltradoPorEstadoPorAdquiriente(opDTO.IdAdquiriente, opDTO.CodEstado);
            }
            else
            {
                operaciones = operacionService.ListadoTodasPorAdquiriente(opDTO.IdAdquiriente);
            }
            

            //operaciones = _operacionService.ListadoTodasPorAdquiriente(opDTO.IdAdquiriente);


            return OperacionMapper.ConvertirAOperacionDTOLista(operaciones);
        }

        // GET: api/Operacion/5
        [HttpGet("{id}", Name = "GetOperacion")]
        public OperacionDTO Get(int id)
        {
            Operacion op = operacionService.ObtenerPorId(id);

            OperacionDTO opDTO = OperacionMapper.ConvertirAOperacionDTO(op);

            return opDTO;
        }


        // POST: api/Default
        [HttpPost]
        public OperacionDTO Post([FromBody] OperacionDTO opRes)
        {
            Operacion op = operacionService.Crear(opRes);

            return OperacionMapper.ConvertirAOperacionDTO(op);
        }

        // PUT: api/Operaciones/5
        [HttpPut]
        public IActionResult Put(OperacionDTO opRes)
        {
            try
            {
                Operacion op = operacionService.Actualizar(opRes.IdOperacion, opRes.CodEstado);
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

        [HttpGet(RouteIdOperacionControl)]
        public IActionResult GetControl(int idOperacion)
        {
            try
            {
                return Ok(new {Mensaje = $"Detalle de control de operacion {idOperacion}"});
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        [HttpPost(RouteIdOperacionControl)]
        public IActionResult PostControlOperacion(int idOperacion, [FromBody] ControlDTO controlDto)
        {
            try
            {
                return Ok(controlService.Crear(controlDto));
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

        [HttpPut(RouteIdOperacionControl)]
        public IActionResult PutControlOperacion(int idOperacion, [FromBody] ControlDTO controlDto)
        {
            try
            {
                return Ok(new {Mensaje = $"Actualizar control de operacion {idOperacion}"});
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
