using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using WildNights.UserService.Api.Common.ModulesConfiguration;
using WildNights.UserService.Application;


namespace WildNights.UserService.Api.RequestPipline;

public static class DependencyInjection
{
    public static IServiceCollection RegisterRequestPipeline(this IServiceCollection services)
    {
        services
            .RegisterModules()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return services;
    }
}
