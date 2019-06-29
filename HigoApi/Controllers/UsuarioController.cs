using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigoApi.Factories;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Services;
using HigoApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private const string RouteUsuarioVehiculos = "{idUsuario}/Vehiculos";
        private const string RouteUsuarioVehiculoPorId = RouteUsuarioVehiculos + "/{idVehiculo}";

        private readonly HigoContext ctx;
        private readonly IUsuarioService usuarioService;
        private readonly IVehiculoService vehiculoService;
        private readonly ParametrosUsuarioRequestValidator parametrosValidator;
        private readonly ErrorResponseFactory errorResponseFactory;

        public UsuarioController(IUsuarioService usuarioService, ParametrosUsuarioRequestValidator parametrosValidator,
            HigoContext ctx, IVehiculoService vehiculoService, ErrorResponseFactory errorResponseFactory)
        {
            this.ctx = ctx;
            this.usuarioService = usuarioService;
            this.parametrosValidator = parametrosValidator;
            this.vehiculoService = vehiculoService;
            this.errorResponseFactory = errorResponseFactory;
        }


        //GET: api/Usuario
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await ctx.Usuario.ToListAsync();
        }

        //GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await ctx.Usuario.FindAsync(id);

            try
            {
                if (usuario == null)
                {
                    const int code = StatusCodes.Status404NotFound;
                    return StatusCode(code, new ErrorResponse(code, "Usuario no encontrado"));
                }

                return usuario;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                const int code = StatusCodes.Status500InternalServerError;
                return StatusCode(code, new ErrorResponse(code, e.Message));
            }

        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuarioEdited)
        {
            try
            {
                var usr = usuarioService.ObtenerUsuarioPorId(id);
                var usuarioValidado = parametrosValidator.ValidateNullsParameter(usr, usuarioEdited);
                usuarioService.ActualizarUsuario(usuarioValidado);
                return new ContentResult()
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                const int code = StatusCodes.Status500InternalServerError;
                return StatusCode(code, new ErrorResponse(code, e.Message));
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            await ctx.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await ctx.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ctx.Usuario.Remove(usuario);
            await ctx.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return ctx.Usuario.Any(e => e.IdUsuario == id);
        }

        [HttpGet(RouteUsuarioVehiculos)]
        public IActionResult GetUsuarioVehiculos(int idUsuario)
        {
            try
            {
                return Ok(vehiculoService.ListarPorIdUsuario(idUsuario));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }

        [HttpGet(RouteUsuarioVehiculoPorId)]
        public IActionResult GetUsuarioVehiculoPorId(int idUsuario, int idVehiculo)
        {
            try
            {
                return Ok(new {mensaje = $"Vehiculo {idVehiculo} del usuario {idUsuario}"});
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }
    }
}
