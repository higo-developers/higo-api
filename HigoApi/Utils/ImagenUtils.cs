using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HigoApi.Utils
{
    public class ImagenUtils
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;
        
        private const string KeyImgFolder = "ImgFolder";

        public ImagenUtils(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }

        public FileStream ObtenerFileStreamPorNombre(string nombreArchivo)
        {
            var rootPath = hostingEnvironment.ContentRootPath;
            var carpetaImagenes = configuration.GetSection(KeyImgFolder).Value;
            
            return File.OpenRead($"{rootPath}{carpetaImagenes}{nombreArchivo}");
        }
    }
}