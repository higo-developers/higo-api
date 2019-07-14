namespace HigoApi.Models.DTO
{
    public class ControlDTO
    {
        public int? Id { get; set; }
        public int IdOperacion { get; set; }

        public int? NivelCombustibleInicial { get; set; }
        public int? HigieneExternaInicial { get; set; }
        public int? HigieneInternaInicial { get; set; }
        public int? EstadoTecnicoInicial { get; set; }

        public int? NivelCombustibleFinal { get; set; }
        public int? HigieneExternaFinal { get; set; }
        public int? HigieneInternaFinal { get; set; }
        public int? EstadoTecnicoFinal { get; set; }
    }
}