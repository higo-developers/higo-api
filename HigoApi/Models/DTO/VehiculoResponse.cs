using System;

namespace HigoApi.Models.DTO
{
    public class VehiculoResponse
    {
        public int Id { get; set; }
        public string PathImagen { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cilindrada { get; set; }
        public LocacionResponse Locacion { get; set; }
        public Nullable<double> PrecioHora { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}