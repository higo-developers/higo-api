using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HigoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MarcaController : ControllerBase
    {
        private readonly HigoContext ctx;

        public MarcaController(HigoContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<Marca> Get()
        {
            return ctx.Marca.ToList();
        }

    }
}