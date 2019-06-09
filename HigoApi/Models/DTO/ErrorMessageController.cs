using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Models.DTO
{
    public class ErrorMessageController
    {
        public int Code { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorMessageController(int code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }
}