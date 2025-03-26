using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WildNights.UserService.Api.Common.Error;

public class ErrorHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public ErrorHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }


    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is not ServiceError serviceError) 
        {
            return true;
        }

        var problemDetails = new ProblemDetails
        {
            Status = (int)serviceError.StatusCode,
            Title = serviceError.ErrorMessage,
            Detail = exception.Message,
            Type = serviceError.StatusCode.ToString()
        };

        var isProblemWritten = await _problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });

        return isProblemWritten;
    }
}
