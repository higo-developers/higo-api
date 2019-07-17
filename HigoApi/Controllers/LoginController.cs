using System;
using System.Linq;
using HigoApi.Builders;
using HigoApi.Models;
using HigoApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HigoApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly HigoContext context;
        private readonly LoginResponseBuilder loginResponseBuilder;

        public LoginController(HigoContext context, LoginResponseBuilder loginResponseBuilder)
        {
            this.context = context;
            this.loginResponseBuilder = loginResponseBuilder;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!request.IsValid())
                    return BadRequest(new ErrorResponse(StatusCodes.Status400BadRequest, "Campo requerido ausente"));

                var usuario = context.Usuario
                    .Include(u => u.IdPerfilNavigation)
                    .FirstOrDefault(u => u.Email.Equals(request.Email) && u.Password.Equals(request.Password));

                if (usuario != null)
                    return Ok(loginResponseBuilder.Build(usuario));

                const int code = StatusCodes.Status403Forbidden;
                return StatusCode(code, new ErrorResponse(code, "E-mail y/o contraseña inválidos"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                const int code = StatusCodes.Status500InternalServerError;
                return StatusCode(code, new ErrorResponse(code, e.Message));
            }
        }
    }
}