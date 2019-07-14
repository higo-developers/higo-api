using System;
using HigoApi.Builders;
using HigoApi.Mappers;
using HigoApi.Models;
using HigoApi.Models.DTO;

namespace HigoApi.Services.Impl
{
    public class ControlService : IControlService
    {
        private readonly HigoContext higoContext;
        private readonly ControlMapper controlMapper;
        private readonly IOperacionService operacionService;
        private readonly ControlResponseBuilder controlResponseBuilder;

        public ControlService(HigoContext higoContext, ControlMapper controlMapper, IOperacionService operacionService,
            ControlResponseBuilder controlResponseBuilder)
        {
            this.higoContext = higoContext;
            this.controlMapper = controlMapper;
            this.operacionService = operacionService;
            this.controlResponseBuilder = controlResponseBuilder;
        }

        public Control ObtenerControlPorIdDeOperacion(int idOperacion)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}