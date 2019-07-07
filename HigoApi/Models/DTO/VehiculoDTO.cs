using System;
using System.Collections.Generic;

namespace HigoApi.Models.DTO
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string PathImagen { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cilindrada { get; set; }
        public LocacionDTO Locacion { get; set; }
        public Nullable<double> PrecioHora { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public List<string> Equipamiento { get; set; }
    }
}