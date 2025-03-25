using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using WildNights.UserService.Api.Common.Errors;
using WildNights.UserService.Api.Common.Interfaces;
using WildNights.UserService.Application.Common.Errors;

namespace WildNights.UserService.Api.Modules;

public class ErrorModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance =
                    $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

                context.ProblemDetails.Extensions["requestId"] = context.HttpContext.TraceIdentifier;
                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions["traceId"] = activity?.Id;
            };
        });
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/error", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is null)
            {                
                return Results.Problem();
            }

            return exception switch
            {
                IServiceException serviceException => Results.Problem(
                    statusCode: (int)serviceException.StatusCode,
                    detail: serviceException.ErrorMessage),
                
                _ => Results.Problem()
            };
        });
        return endpoints;
    }
}