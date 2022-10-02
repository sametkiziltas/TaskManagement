using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using TaskManagement.API.Base;

namespace TaskManagement.API.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message, context.Exception);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            
            var errorResult = new JsonResult(new List<ErrorModel> {new ErrorModel("500", "Error occured")});
            context.Result = errorResult;

            Console.WriteLine(errorResult);
        }
    }
}
