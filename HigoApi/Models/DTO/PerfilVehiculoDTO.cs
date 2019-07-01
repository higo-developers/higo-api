namespace HigoApi.Models.DTO
{
    public class PerfilVehiculoDTO
    {
        public int Id { get; set; }

        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string Combustible { get; set; }
        public string Patente { get; set; }
        public string Anno { get; set; }

        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int Cilindrada { get; set; }

        // < Datos de equipamiento >

        public bool Ac { get; set; }
        public bool Da { get; set; }
        public bool Dh { get; set; }
        public bool Alarma { get; set; }
        public bool CierreCentralizado { get; set; }
        public bool RompenieblasDelantero { get; set; }
        public bool RompenieblasTrasero { get; set; }
        public bool Airbag { get; set; }
        public bool Abs { get; set; }
        public bool ControlTraccion { get; set; }
        public bool TapizadoCuero { get; set; }

        // <! Datos de equipamiento >
    }
}