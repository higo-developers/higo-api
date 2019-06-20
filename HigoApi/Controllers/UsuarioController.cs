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

namespace HigoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly HigoContext ctx;

        public UsuarioController(HigoContext context)
        {
            ctx = context;
        }

        // GET: api/Usuario
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        //{
        //    return await ctx.Usuario.ToListAsync();
        //}

        // GET: api/Usuario/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuario(int id)
        //{
        //    var usuario = await ctx.Usuario.FindAsync(id);

        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuario;
        //}

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuarioEdited)
        {
            try
            {
                var usr = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id);

                usr.Nombre = usuarioEdited.Nombre != null ? usuarioEdited.Nombre : usr.Nombre;
                usr.Apellido = usuarioEdited.Apellido != null ? usuarioEdited.Apellido : usr.Apellido;
                usr.Dni = usuarioEdited.Dni != null ? usuarioEdited.Dni : usr.Dni;
                usr.IdPerfil = usuarioEdited.IdPerfil != null ? usuarioEdited.IdPerfil : usr.IdPerfil;
                usr.IdLocacion = usuarioEdited.IdLocacion != null ? usuarioEdited.IdLocacion : usr.IdLocacion;
                usr.FechaAlta = usuarioEdited.FechaAlta != null ? usuarioEdited.FechaAlta : usr.FechaAlta;
                usr.Email = usuarioEdited.Email != null ? usuarioEdited.Email : usr.Email;
                usr.Password = usuarioEdited.Password != null ? usuarioEdited.Password : usr.Password;
                usr.Telefono = usuarioEdited.Telefono != null ? usuarioEdited.Telefono : usr.Telefono;


                ctx.Entry(usr).State = EntityState.Modified;

                
                await ctx.SaveChangesAsync();
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

            return NoContent();
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
    }
}
