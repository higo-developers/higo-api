using System;
using HigoApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Factories
{
    public class ErrorResponseFactory
    {
        public IActionResult InternalServerErrorResponse(Exception exception)
        {
            Console.WriteLine(exception);
            return new ObjectResult(new ErrorResponse(StatusCodes.Status500InternalServerError, exception.Message));
        }
    }
}