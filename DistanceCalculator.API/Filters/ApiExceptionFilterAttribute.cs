using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistanceCalculator.API.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);
        HandleException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (type == typeof(ValidationException))
        {
            var errors = new Dictionary<string, string[]>()
            {
                { "ValidationErrors", new string[] { context.Exception.Message } }
            };
            var details = new ValidationProblemDetails(errors);

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
