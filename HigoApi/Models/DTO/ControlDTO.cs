using HigoApi.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HigoApi.Models.DTO
{
    public class ControlDTO
    {
        public int? Id { get; set; }
        public int IdOperacion { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public NivelCombustible? NivelCombustibleInicial { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NivelHigiene? HigieneExternaInicial { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NivelHigiene? HigieneInternaInicial { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FuncionamientoGeneral? FuncionamientoGeneralInicial { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public NivelCombustible? NivelCombustibleFinal { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NivelHigiene? HigieneExternaFinal { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public NivelHigiene? HigieneInternaFinal { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FuncionamientoGeneral? FuncionamientoGeneralFinal { get; set; }
    }
}