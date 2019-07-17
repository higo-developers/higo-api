using HigoApi.Mappers;
using HigoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CilindradasController : ControllerBase
    {
        private readonly IOpcionesService opcionesService;
        private readonly OpcionesMapper opcionesMapper;

        public CilindradasController(IOpcionesService opcionesService, OpcionesMapper opcionesMapper)
        {
            this.opcionesService = opcionesService;
            this.opcionesMapper = opcionesMapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(opcionesMapper.CilindradasToDTOList(opcionesService.ListarCilindradas()));
        }
    }
}