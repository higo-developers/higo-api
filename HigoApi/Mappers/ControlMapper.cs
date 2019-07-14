using System;
using HigoApi.Enums;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Mappers
{
    public class ControlMapper
    {
        public Control FromDtoParaCreacion(ControlDTO controlDto)
        {
            var control = new Control();

            control.IdOperacion = controlDto.IdOperacion;
            control.NivelCombustibleInicial = (int) controlDto.NivelCombustibleInicial.GetValueOrDefault(NivelCombustible.ALTO);
            control.HigieneExternaInicial = (int) controlDto.HigieneExternaInicial.GetValueOrDefault(NivelHigiene.BUENO);
            control.HigieneInternaInicial = (int) controlDto.HigieneInternaInicial.GetValueOrDefault(NivelHigiene.BUENO);
            control.FuncionamientoGeneralInicial = (int) controlDto.FuncionamientoGeneralInicial.GetValueOrDefault(FuncionamientoGeneral.BUENO);
            control.FechaHoraControlInicial = DateTime.Now;
            
            return control;
        }
    }
}