using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using System.Reflection;
using WildNights.UserService.Api.Common.Error;
using WildNights.UserService.Api.Common.ModulesConfiguration;
using WildNights.UserService.Domain.Common.Errors.Abstract;

namespace WildNights.UserService.Api.RequestPipline;

public static class DependencyInjection
{
    public static IServiceCollection RegisterRequestPipeline(
        this IServiceCollection services)
    {
        services
            .RegisterModules()
            .AddEndpointsApiExplorer()
            .AddMappings()
            .AddSwaggerGen()
            .ConfigureProblemDetails();

        services.AddExceptionHandler<ErrorHandler>();

        return services;
    }

    public static IServiceCollection ConfigureProblemDetails(
        this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance =
                    $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

                context.ProblemDetails.Extensions["requestId"] = context.HttpContext.TraceIdentifier;
               
                Activity? activity = context.HttpContext.Features
                    .Get<IHttpActivityFeature>()?.Activity;

                context.ProblemDetails.Extensions["traceId"] = activity?.Id;
            };
        });
        return services;
    }

    public static IServiceCollection AddMappings(
        this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}
