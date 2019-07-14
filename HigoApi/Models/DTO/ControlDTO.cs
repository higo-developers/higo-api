using HigoApi.Enums;

namespace HigoApi.Models.DTO
{
    public class ControlDTO
    {
        public int? Id { get; set; }
        public int IdOperacion { get; set; }

        public NivelCombustible? NivelCombustibleInicial { get; set; }
        public NivelHigiene? HigieneExternaInicial { get; set; }
        public NivelHigiene? HigieneInternaInicial { get; set; }
        public FuncionamientoGeneral? FuncionamientoGeneralInicial { get; set; }

        public NivelCombustible? NivelCombustibleFinal { get; set; }
        public NivelHigiene? HigieneExternaFinal { get; set; }
        public NivelHigiene? HigieneInternaFinal { get; set; }
        public FuncionamientoGeneral? FuncionamientoGeneralFinal { get; set; }
    }
}