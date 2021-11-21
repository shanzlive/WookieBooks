using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using WookieBooks.Application.Exceptions;

namespace WookieBooks.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomexceptionFilterAttribute : ExceptionFilterAttribute 
    {
        private readonly ILogger<CustomexceptionFilterAttribute> _logger;

        public CustomexceptionFilterAttribute(ILogger<CustomexceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException (ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            switch(context.Exception)
            {
                case BookExistException exception:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    context.Result = new JsonResult(exception.Message);
                    _logger.LogError(context.Exception, exception.Message);
                    break;
                case BookNotExistException exception:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new JsonResult(exception.Message);
                    _logger.LogError(context.Exception, exception.Message);
                    break;
                case ValidationException exception:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new JsonResult(new
                    {
                        Message = "A bad request was recieved",
                        Details = exception.Errors.Select(x => new { Message = x.ErrorMessage, Target = x.PropertyName })
                    });
                    break;

                default:
                    const string exceptionMessage = "An error occured";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Result = new JsonResult("An error occured");
                    _logger.LogError(context.Exception, exceptionMessage);
                    break;
            }
        }
        
    }
    
}
