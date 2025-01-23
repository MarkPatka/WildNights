using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WildNights.UserService.Application.Common.Interfaces;
using WildNights.UserService.Infrastructure.Authentication;

namespace WildNights.UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
