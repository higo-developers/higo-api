using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HigoApi.Models.DTO;
using HigoApi.Services;
using HigoApi.Validators;

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly HigoContext ctx;
        private readonly IUsuarioService usuarioService;
        private readonly ParametrosUsuarioRequestValidator parametrosValidator;

        public UsuarioController(IUsuarioService usuarioService, ParametrosUsuarioRequestValidator parametrosValidator, HigoContext ctx)
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
        public IActionResult PostUsuario(RegistrarUsuarioDTO usuario)
        {
            try
            {
                Usuario usr = usuarioService.RegistrarUsuario(usuario);
                if (usr == null)
                {
                    const int code = StatusCodes.Status422UnprocessableEntity;
                    return StatusCode(code, new ErrorResponse(code, "Informacion de usuario no valida"));
                }
                //return CreatedAtAction("GetUsuario", new { id = usr.IdUsuario }, usuario);
                return Ok(usr) ;
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

        private bool UsuarioExists(int id)
        {
            return ctx.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
