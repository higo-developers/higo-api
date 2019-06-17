using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HigoApi.Models;
using HigoApi.Models.DTO;
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
        public IActionResult Login([FromBody] ParametrosLogin usuarioParam)
        {
            if (ModelState.IsValid)
            {
                var result = context.Usuario.FirstOrDefault(x => x.Email == usuarioParam.Email && x.Password == usuarioParam.Password);  
                if (result != null)
                {
                    return BuildToken(usuarioParam);
                }
                else
                {

                    ErrorResponse err = new ErrorResponse(422,"dasdasd");
                    return UnprocessableEntity(err);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        private IActionResult BuildToken(ParametrosLogin usuarioParam)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioParam.Email),
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

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });
        }
    }
}