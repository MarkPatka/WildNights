using WildNights.UserService.Application;


namespace WildNights.UserService.Api.RequestPipline;

public static class DependencyInjection
{
    public static IServiceCollection RegisterRequestPipeline(this IServiceCollection services)
    {
        services.AddGlobalErrorHandling()
                .AddApplication();

        return services;
    }

    public static IServiceCollection AddGlobalErrorHandling(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;


            };
        });
        return services;
    }
}
