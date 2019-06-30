using System;
using System.ComponentModel.DataAnnotations;
using HigoApi.Factories;
using HigoApi.Models.DTO;
using HigoApi.Services;
using HigoApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesController : ControllerBase
    {
        private const string RoutePerfilVehiculos = "{idUsuario}/Vehiculos";
        private const string RoutePerfilVehiculoPorId = RoutePerfilVehiculos + "/{idVehiculo}";
        
        private readonly ErrorResponseFactory errorResponseFactory;
        private readonly IVehiculoService vehiculoService;
        private readonly UsuarioVehiculoValidator usuarioVehiculoValidator;

        public PerfilesController(ErrorResponseFactory errorResponseFactory, IVehiculoService vehiculoService, UsuarioVehiculoValidator usuarioVehiculoValidator)
        {
            this.errorResponseFactory = errorResponseFactory;
            this.vehiculoService = vehiculoService;
            this.usuarioVehiculoValidator = usuarioVehiculoValidator;
        }

        [HttpGet(RoutePerfilVehiculos)]
        public IActionResult GetPerfilVehiculos(int idUsuario)
        {
            try
            {
                return Ok(vehiculoService.ListarPorIdUsuario(idUsuario));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        [HttpGet(RoutePerfilVehiculoPorId)]
        public IActionResult GetPerfilVehiculoPorId(int idUsuario, int idVehiculo)
        {
            try
            {
                usuarioVehiculoValidator.Validate(idUsuario, idVehiculo);
                return Ok(vehiculoService.ObtenerPorId(idVehiculo));
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve);
                return UnprocessableEntity(new ErrorResponse(StatusCodes.Status422UnprocessableEntity, ve.Message));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }
    }
}