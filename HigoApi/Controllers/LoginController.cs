using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HigoApi.Models;
using HigoApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HigoApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HigoContext context;

        public LoginController(IConfiguration configuration, HigoContext context)
        {
            _configuration = configuration;
            this.context = context;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!request.IsValid())
                    return BadRequest(new ErrorResponse(StatusCodes.Status400BadRequest, "Campo requerido ausente"));
                
                var result = context.Usuario.FirstOrDefault( u => u.Email.Equals(request.Email) && u.Password.Equals(request.Password) );

                if (result != null)
                    return BuildToken(request);

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

        private IActionResult BuildToken(LoginRequest loginRequest)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, loginRequest.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret_Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(5);
            
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "higo.com.ar",
               audience: "higo.com.ar",
               claims: claims,
               expires: expiration,
               signingCredentials: creds
            );

            return Ok(new TokenResponse(
                new JwtSecurityTokenHandler().WriteToken(token),
                expiration)
            );
        }
    }
}