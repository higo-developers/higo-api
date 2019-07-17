using System;
using System.Collections.Generic;

namespace HigoApi.Models
{
    public partial class Control
    {
        public int IdControl { get; set; }
        public int? IdOperacion { get; set; }
        public DateTime? FechaHoraControlInicial { get; set; }
        public int? FuncionamientoGeneralFinal { get; set; }
        public int? FuncionamientoGeneralInicial { get; set; }
        public DateTime? FechaHoraControlFinal { get; set; }
        public int? HigieneExternaFinal { get; set; }
        public int? HigieneExternaInicial { get; set; }
        public int? HigieneInternaFinal { get; set; }
        public int? HigieneInternaInicial { get; set; }
        public int? NivelCombustibleFinal { get; set; }
        public int? NivelCombustibleInicial { get; set; }
    }
}
