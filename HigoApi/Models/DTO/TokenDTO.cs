using System;

namespace HigoApi.Models.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public TokenDTO(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}