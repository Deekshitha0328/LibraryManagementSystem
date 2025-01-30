using LMS.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BookNotFoundException)
        {
            HandleBookNotFoundException(context);
        }
        else
        {
            HandleInternalServerError(context);

        }
    }

    private void HandleInternalServerError(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = context.Exception.Message
        };
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;

    }

    private void HandleBookNotFoundException(ExceptionContext context)
    {
        var problemDetails = new ProblemDetails
        {
            Title = "Book not found",
            Status = StatusCodes.Status404NotFound,
            Detail = context.Exception.Message
        };
        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;
    }
}
