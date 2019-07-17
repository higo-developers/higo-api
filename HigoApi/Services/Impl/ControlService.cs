using System;
using System.Globalization;
using System.Linq;
using HigoApi.Builders;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Utils;

namespace HigoApi.Services.Impl
{
    public class ControlService : IControlService
    {
        private readonly HigoContext higoContext;
        private readonly ControlMapper controlMapper;
        private readonly IOperacionService operacionService;
        private readonly ControlResponseBuilder controlResponseBuilder;
        private readonly ControlUtils controlUtils;

        public ControlService(HigoContext higoContext, ControlMapper controlMapper, IOperacionService operacionService,
            ControlResponseBuilder controlResponseBuilder, ControlUtils controlUtils)
        {
            this.higoContext = higoContext;
            this.controlMapper = controlMapper;
            this.operacionService = operacionService;
            this.controlResponseBuilder = controlResponseBuilder;
            this.controlUtils = controlUtils;
        }

        public Control ObtenerPorId(int idControl)
        {
            return higoContext.Control.FirstOrDefault(c => c.IdControl.Equals(idControl));
        }

        public Control ObtenerControlPorIdDeOperacion(int idOperacion)
        {
            return higoContext.Control
                .OrderByDescending(c => c.FechaHoraControlInicial)
                .FirstOrDefault(c => c.IdOperacion.Equals(idOperacion));
        }

        public ControlDTO ObtenerControlDtoPorIdOperacion(int idOperacion)
        {
            return controlMapper.ToDto(ObtenerControlPorIdDeOperacion(idOperacion));
        }

        public ControlResponse Crear(ControlDTO controlDto)
        {
            Control control = controlMapper.FromDtoParaCreacion(controlDto);

            higoContext.Control.Add(control);

            higoContext.SaveChanges();

            var operacion = operacionService.Actualizar(controlDto.IdOperacion, EstadoOperacion.VIGENTE);

            return controlResponseBuilder.Build(control, operacion);
        }

        public ControlResponse Actualizar(ControlDTO controlDto)
        {
            var control = ObtenerPorId(controlDto.Id.GetValueOrDefault());

            control.FechaHoraControlFinal = DateTime.Now;
            control.NivelCombustibleFinal = (int) controlDto.NivelCombustibleFinal.GetValueOrDefault();
            control.HigieneExternaFinal = (int) controlDto.HigieneExternaFinal.GetValueOrDefault();
            control.HigieneInternaFinal = (int) controlDto.HigieneInternaFinal.GetValueOrDefault();
            control.FuncionamientoGeneralFinal = (int) controlDto.FuncionamientoGeneralFinal.GetValueOrDefault();

            higoContext.Control.Update(control);
            higoContext.SaveChanges();

            var operacion = operacionService.ObtenerPorId(controlDto.IdOperacion);

            var montoEfectivo = controlUtils.CalcularMontoEfectivo(control, operacion.MontoAcordado.GetValueOrDefault());

            operacionService.ActualizarMontoEfectivo(operacion, montoEfectivo);
            operacionService.Actualizar(operacion.IdOperacion, EstadoOperacion.PAGO_PENDIENTE);

            var controlResponse = controlResponseBuilder.Build(control, operacion);
            controlResponse.Mensaje = $"Monto final de operacion: {operacion.MontoEfectivo.GetValueOrDefault().ToString("C", CultureInfo.CurrentCulture)}";

            return controlResponse;
        }
    }
}