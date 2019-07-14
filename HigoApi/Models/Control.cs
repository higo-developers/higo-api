using System;

namespace HigoApi.Models
{
    public partial class Control
    {
        public int IdControl { get; set; }
        public int? IdOperacion { get; set; }
        public int IdTipoControl { get; set; }
        public DateTime? FechaHoraControlInicial { get; set; }
        public DateTime? FechaHoraControlFinal { get; set; }

        public int? NivelCombustibleInicial { get; set; }
        public int? HigieneExternaInicial { get; set; }
        public int? HigieneInternaInicial { get; set; }
        public int? EstadoTecnicoInicial { get; set; }

        public int? NivelCombustibleFinal { get; set; }
        public int? HigieneExternaFinal { get; set; }
        public int? HigieneInternaFinal { get; set; }
        public int? EstadoTecnicoFinal { get; set; }

        public virtual Operacion IdOperacionNavigation { get; set; }
        public virtual TipoControl IdTipoControlNavigation { get; set; }
    }
}