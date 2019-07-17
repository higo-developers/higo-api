using System;
using System.ComponentModel.DataAnnotations;
using HigoApi.Factories;
using HigoApi.Mappers;
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
        private readonly ErrorResponseFactory errorResponseFactory;

        private readonly VehiculoMapper vehiculoMapper;

        public VehiculosController(IVehiculoService vehiculoService,
            ParametrosBusquedaVehiculoValidator parametrosValidator, ErrorResponseFactory errorResponseFactory,
            VehiculoMapper vehiculoMapper)
        {
            this.vehiculoService = vehiculoService;
            this.parametrosValidator = parametrosValidator;
            this.errorResponseFactory = errorResponseFactory;
            this.vehiculoMapper = vehiculoMapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ParametrosBusquedaVehiculo parametros)
        {
            try
            {
                parametrosValidator.Validate(parametros);
                return Ok(vehiculoMapper.ToVehiculoDTOList(vehiculoService.Listar(parametros)));
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
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(vehiculoMapper.ToVehiculoDTO(vehiculoService.ObtenerPorId(id)));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }
    }
}