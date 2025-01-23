using Microsoft.Extensions.DependencyInjection;
using WildNights.UserService.Application.Common.Interfaces;

namespace WildNights.UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }

}
