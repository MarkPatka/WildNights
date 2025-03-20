using Microsoft.AspNetCore.Diagnostics;
using WildNights.UserService.Api.Common.Interfaces;

namespace WildNights.UserService.Api.Modules;

public class ErrorModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/error", (HttpContext context) =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is null)
            {
                //handle
                return Results.Problem();
            }

            //custom global err handling logic
            return Results.Problem();

        });
        return endpoints;
    }
}