using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HigoApi.Services;
using HigoApi.Models;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionService notificacionService;

        public NotificacionesController(INotificacionService notificacionService)
        {
            this.notificacionService = notificacionService;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public IEnumerable<Notificacion> GetAll([FromBody] int idUsuario)
        {
            List<Notificacion> nots = notificacionService.ObtenerListado(idUsuario);
            return nots;
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}", Name = "GetNotificacion")]
        public Notificacion Get(int id)
        {
            return notificacionService.ObtenerPorId(id);
        }

        // PUT: api/Notificaciones/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            notificacionService.Modificar(id);
        }

    }
}
