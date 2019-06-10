using HigoApi.Models.DTO;
using HigoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ParametrosBusquedaVehiculo parametros)
        {
            return Ok(vehiculoService.Listar(parametros));
        }
    }
}