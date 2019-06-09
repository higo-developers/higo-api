using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigoApi.Models.DTO
{
    public class ParametrosLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
