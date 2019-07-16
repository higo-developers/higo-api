using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HigoApi.Builders;
using HigoApi.Enums;
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
    public class UsuariosController : ControllerBase
    {
        private readonly HigoContext ctx;
        private readonly IUsuarioService usuarioService;
        private readonly UsuarioRequestValidator parametrosValidator;
        private readonly IOperacionService operacionService;
        private readonly OperacionesClasificadasDTOBuilder operacionesClasificadasDtoBuilder;
        private readonly ErrorResponseFactory errorResponseFactory;

        private const string RouteUsuarioPorMailYOrigen = "{email}/origen/{codigoOrigen}";
        private const string RouteUsuarioOperaciones = "{id}/operaciones";
        
        private const string ErrorMessageUsuarioNoEncontrado = "Usuario no encontrado";
        private const string ErrorMessageUsuarioNoEncontradoConMailYOrigen = "No se ha encontrado usuario con mail {0} y origen {1}";

        public UsuariosController(HigoContext ctx, IUsuarioService usuarioService,
            UsuarioRequestValidator parametrosValidator, IOperacionService operacionService,
            OperacionesClasificadasDTOBuilder operacionesClasificadasDtoBuilder,
            ErrorResponseFactory errorResponseFactory)
        {
            this.ctx = ctx;
            this.usuarioService = usuarioService;
            this.parametrosValidator = parametrosValidator;
            this.operacionService = operacionService;
            this.operacionesClasificadasDtoBuilder = operacionesClasificadasDtoBuilder;
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
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = usuarioService.ObtenerUsuarioPorId(id);
                
                if (usuario == null)
                    return NotFound(new ErrorResponse(StatusCodes.Status404NotFound, ErrorMessageUsuarioNoEncontrado));

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
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
                    new ErrorResponse(StatusCodes.Status404NotFound, string.Format(ErrorMessageUsuarioNoEncontradoConMailYOrigen, email, origen))
                );

            return Ok(usuario);
        }

        [HttpGet(RouteUsuarioOperaciones)]
        public IActionResult OperacionesDeUsuario(int id)
        {
            try
            {
                return Ok(operacionesClasificadasDtoBuilder.Build(operacionService.ListadoOperacionesDeUsuario(id), id));
            }
            catch (Exception e)
            {
                return errorResponseFactory.InternalServerErrorResponse(e);
            }
        }
    }
}
