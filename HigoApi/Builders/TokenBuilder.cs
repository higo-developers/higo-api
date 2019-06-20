using System;
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
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[ConfigurationSecretKey]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(TokenExpirationHours);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "higo.com.ar",
                audience: "higo.com.ar",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new TokenDTO(
                new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            );
        }
    }
}