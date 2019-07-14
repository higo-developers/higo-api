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

        public ControlDTO ToDto(Control control)
        {
            if (control is null)
                throw new ArgumentNullException();

            var controlDto = new ControlDTO();

            controlDto.Id = control.IdControl;
            controlDto.IdOperacion = control.IdOperacion.GetValueOrDefault();

            if (control.NivelCombustibleInicial.HasValue)
                controlDto.NivelCombustibleInicial = (NivelCombustible) control.NivelCombustibleInicial;
            if (control.HigieneExternaInicial.HasValue)
                controlDto.HigieneExternaInicial = (NivelHigiene) control.HigieneExternaInicial;
            if (control.HigieneInternaInicial.HasValue)
                controlDto.HigieneInternaInicial = (NivelHigiene) control.HigieneInternaInicial;
            if (control.FuncionamientoGeneralInicial.HasValue)
                controlDto.FuncionamientoGeneralInicial = (FuncionamientoGeneral) control.FuncionamientoGeneralInicial;
            if (control.NivelCombustibleFinal.HasValue)
                controlDto.NivelCombustibleFinal = (NivelCombustible) control.NivelCombustibleFinal;
            if (control.HigieneExternaFinal.HasValue)
                controlDto.HigieneExternaFinal = (NivelHigiene) control.HigieneExternaFinal;
            if (control.HigieneInternaFinal.HasValue)
                controlDto.HigieneInternaFinal = (NivelHigiene) control.HigieneInternaFinal;
            if (control.FuncionamientoGeneralFinal.HasValue)
                controlDto.FuncionamientoGeneralFinal = (FuncionamientoGeneral) control.FuncionamientoGeneralFinal;

            return controlDto;
        }
    }
}