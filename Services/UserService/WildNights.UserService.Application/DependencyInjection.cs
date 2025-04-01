using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WildNights.UserService.Application.Authentication.Commands.Register;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Application.Common.Behaviors;


namespace WildNights.UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<IPipelineBehavior<RegisterCommand, AuthenticationResult>, 
                           ValidateRegisterCommandBehavior>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

}
