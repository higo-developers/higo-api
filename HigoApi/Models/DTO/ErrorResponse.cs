using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Models.DTO
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorResponse(int code, string errorMessage)
        {
            ErrorCode = code;
            ErrorMessage = errorMessage;
        }
    }
}