using HigoApi.Mappers;
using HigoApi.Models.DTO;
using HigoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private const string RouteMarcasPorId = "{idMarca}";
        private const string RouteModelosMarca = RouteMarcasPorId + "/Modelos";

        private readonly IMarcaService marcaService;
        private readonly MarcaMapper marcaMapper;

        public MarcasController(IMarcaService marcaService, MarcaMapper marcaMapper)
        {
            this.marcaService = marcaService;
            this.marcaMapper = marcaMapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(marcaMapper.ToMarcaDTOList(marcaService.Listar()));
        }

        [HttpGet(RouteMarcasPorId)]
        public IActionResult GetPorId(int idMarca)
        {
            return Ok(marcaMapper.ToMarcaDto(marcaService.ObtenerPorId(idMarca)));
        }

        [HttpGet(RouteModelosMarca)]
        public IActionResult GetModelosMarca(int idMarca)
        {
            return Ok(marcaService.ListarModelosDeMarca(idMarca).ConvertAll(m => new ModeloMarcaDTO {Id = m.IdModeloMarca, Descripcion = m.Descripcion}));
        }
    }
}