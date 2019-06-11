using System;
using System.ComponentModel.DataAnnotations;
using HigoApi.Models.DTO;
using HigoApi.Services;
using HigoApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService vehiculoService;
        private readonly ParametrosBusquedaVehiculoValidator parametrosValidator;

        public VehiculosController(IVehiculoService vehiculoService,
            ParametrosBusquedaVehiculoValidator parametrosValidator)
        {
            this.vehiculoService = vehiculoService;
            this.parametrosValidator = parametrosValidator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ParametrosBusquedaVehiculo parametros)
        {
            try
            {
                parametrosValidator.Validate(parametros);
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve);
                return BadRequest(new ErrorResponse(StatusCodes.Status400BadRequest, ve.Message));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe);
                return UnprocessableEntity(new ErrorResponse(StatusCodes.Status422UnprocessableEntity, fe.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var code = StatusCodes.Status500InternalServerError;
                return StatusCode(code, new ErrorResponse(code, e.Message));
            }

            return Ok(vehiculoService.Listar(parametros));
        }
    }
}