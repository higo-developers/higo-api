using System;
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

        public ControlService(HigoContext higoContext, ControlMapper controlMapper, IOperacionService operacionService)
        {
            this.higoContext = higoContext;
            this.controlMapper = controlMapper;
            this.operacionService = operacionService;
        }

        public Control ObtenerControlPorIdDeOperacion(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public Control Crear(ControlDTO controlDto)
        {
            Control control = controlMapper.FromDtoParaCreacion(controlDto);

            higoContext.Control.Add(control);
            
            higoContext.SaveChanges();
            operacionService.Actualizar(controlDto.IdOperacion, EstadoOperacion.VIGENTE);

            return control;
        }

        public Control Actualizar(ControlDTO controlDto)
        {
            throw new NotImplementedException();
        }
    }
}