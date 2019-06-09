using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HigoApi.Models;
using Microsoft.AspNetCore.Identity;
using HigoApi.Models.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace HigoApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    public class LoginController : Controller
    {
        //private readonly UserManager<Usuario> _userManager;
        //private readonly SignInManager<Usuario> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly HigoContext context;

        public LoginController(IConfiguration configuration, HigoContext context)
        {
            _configuration = configuration;
            this.context = context;
        }



        //public LoginController(
        //    UserManager<Usuario> userManager, 
        //    SignInManager<Usuario> signInManager,
        //    IConfiguration _configuration)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    this._configuration = _configuration;
        //}



        [HttpPost]
        [Route("login")]
        //public async Task<IActionResult> Login([FromBody] ParametrosLogin usuarioParam)
        public IActionResult Login([FromBody] ParametrosLogin usuarioParam)
        {
            if (ModelState.IsValid)
            {
                //var result = await _signInManager.PasswordSignInAsync(usuarioParam.Email, usuarioParam.Password, isPersistent: false, lockoutOnFailure: false);
                var result = context.Usuario.FirstOrDefault(x => x.Email == usuarioParam.Email && x.Password == usuarioParam.Password);  
                if (result != null)
                {
                    return BuildToken(usuarioParam);
                }
                else
                {

                    ErrorMessageController err = new ErrorMessageController(422,"dasdasd");
                    return UnprocessableEntity(err);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        [Route("logout")]
        //public async Task<IActionResult> Login([FromBody] ParametrosLogin usuarioParam)
        public IActionResult Logout([FromBody] string token)
        {
            if (ModelState.IsValid)
            {
                //var result = await _signInManager.PasswordSignInAsync(usuarioParam.Email, usuarioParam.Password, isPersistent: false, lockoutOnFailure: false);
                var result = context.Usuario.FirstOrDefault(x => x.Email == usuarioParam.Email && x.Password == usuarioParam.Password);
                if (result != null)
                {
                    return BuildToken(usuarioParam);
                }
                else
                {

                    ErrorMessageController err = new ErrorMessageController(422, "dasdasd");
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
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });
        }
    }
}