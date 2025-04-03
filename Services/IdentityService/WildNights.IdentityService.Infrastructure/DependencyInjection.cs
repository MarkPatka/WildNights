using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WildNights.IdentityService.Application.Common.Interfaces.Authentication;
using WildNights.IdentityService.Application.Common.Interfaces.Persistence;
using WildNights.IdentityService.Infrastructure.Authentication;
using WildNights.IdentityService.Infrastructure.Persistence;

namespace WildNights.IdentityService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
