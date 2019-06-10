using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models.DTO
{
    public class VehiculoResponse
    {
        public string PathImagen { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cilindrada { get; set; }
        public string Localidad { get; set; }
        public double PrecioHora { get; set; }
    }
}
