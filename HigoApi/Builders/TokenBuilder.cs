using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HigoApi.Models.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HigoApi.Builders
{
    public class TokenBuilder
    {
        private readonly IConfiguration configuration;
        private const string ConfigurationSecretKey = "Secret_Key";
        private const int TokenExpirationHours = 5;

        public TokenBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public TokenDTO Build(string userEmail)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[ConfigurationSecretKey]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(TokenExpirationHours);

            var token = new JwtSecurityToken(
                "higo.com.ar",
                "higo.com.ar",
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );

            return new TokenDTO(
                new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            );
        }
    }
}