using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HigoApi.Enums;
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
    public class UsuariosController : ControllerBase
    {
        private readonly HigoContext ctx;
        private readonly IUsuarioService usuarioService;
        private readonly UsuarioRequestValidator parametrosValidator;

        private const string RouteUsuarioPorMailYOrigen = "{email}/origen/{codigoOrigen}";
        
        private const string ErrorMessageUsuarioNoEncontrado = "No se ha encontrado usuario con mail {0} y origen {1}";
        
        public UsuariosController(IUsuarioService usuarioService, UsuarioRequestValidator parametrosValidator, HigoContext ctx)
        {
            this.ctx = ctx;
            this.usuarioService = usuarioService;
            this.parametrosValidator = parametrosValidator;
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
        public IActionResult PutUsuario(int id, [FromBody] RegistrarUsuarioDTO usuarioEdited)
        {
            try
            {
                var usr = usuarioService.ObtenerUsuarioPorId(id);
                parametrosValidator.IsValidatedUser(usuarioEdited);
                var usuarioValidado = parametrosValidator.ValidateNullsParameter(usr, usuarioEdited);
                usuarioService.ActualizarUsuario(usuarioValidado);

                return Ok(StatusCodes.Status201Created);
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve);
                return BadRequest(new ErrorResponse(StatusCodes.Status400BadRequest, ve.Message));
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
        public IActionResult PostUsuario(RegistrarUsuarioDTO usuario)
        {
            try
            {
                Usuario usr = usuarioService.RegistrarUsuario(usuario);
                return Ok(usr) ;
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve);
                return BadRequest(new ErrorResponse(StatusCodes.Status400BadRequest, ve.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                const int code = StatusCodes.Status500InternalServerError;
                return StatusCode(code, new ErrorResponse(code, e.Message));
            }
           
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

        [HttpGet(RouteUsuarioPorMailYOrigen)]
        public IActionResult UsuarioPorEmailYOrigen(string email, string codigoOrigen)
        {
            var origen = (OrigenUsuario) Enum.Parse(typeof(OrigenUsuario), codigoOrigen, true);
            var usuario = usuarioService.UsuarioPorEmailYOrigen(email, origen);

            if (usuario == null)
                return NotFound(
                    new ErrorResponse(StatusCodes.Status404NotFound, string.Format(ErrorMessageUsuarioNoEncontrado, email, origen))
                );

            return Ok(usuario);
        }
    }
}
