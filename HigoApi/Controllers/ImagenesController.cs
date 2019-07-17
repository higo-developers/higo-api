using HigoApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenesController : ControllerBase
    {
        private readonly ImagenUtils imagenUtils;

        private const string ContentTypePNG = "image/png";

        public ImagenesController(ImagenUtils imagenUtils)
        {
            this.imagenUtils = imagenUtils;
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImagenPorNombre(string fileName)
        {
            return File(imagenUtils.ObtenerFileStreamPorNombre(fileName), ContentTypePNG);
        }
    }
}