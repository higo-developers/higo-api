﻿namespace HigoApi.Models
{
    public partial class Locacion
    {
        public Locacion()
        {
        }

        public int IdLocacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Localidad { get; set; }
        public string Pais { get; set; }
        public string Partido { get; set; }
        public string Provincia { get; set; }
    }
}