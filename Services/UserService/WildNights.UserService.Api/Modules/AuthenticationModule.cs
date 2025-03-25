using WildNights.UserService.Api.Common.Interfaces;
using WildNights.UserService.Application.Common.Errors;
using WildNights.UserService.Contracts.Authentication;
using AuthenticationService = WildNights.UserService.Application.Services.Authentication.AuthenticationService;
using IAuthenticationService = WildNights.UserService.Application.Services.Authentication.IAuthenticationService;

namespace WildNights.UserService.Api.Modules;

public class AuthenticationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();


        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("auth/register", (RegisterRequest request, IAuthenticationService _authenticationService) =>
        {
            try
            {
                var registerResult = _authenticationService.Register(
                    request.FirstName, request.LastName, request.Email, request.Password);

                var registerResponse = new AuthenticationResponse(
                    registerResult.User.Id,
                    registerResult.User.FirstName,
                    registerResult.User.LastName,
                    registerResult.User.Email,
                    registerResult.Token);

                return Results.Ok(registerResponse);
            }
            catch (DuplicateEmailException)
            {
                throw new DuplicateEmailException();
            }            
        });

        endpoints.MapPost("auth/login", (LoginRequest request, IAuthenticationService _authenticationService) =>
        {
            var loginResult = _authenticationService.Login(
                request.Email, request.Password);

            var loginResponse = new AuthenticationResponse(
                loginResult.User.Id,
                loginResult.User.FirstName,
                loginResult.User.LastName,
                loginResult.User.Email,
                loginResult.Token);

            return Results.Ok(loginResponse);
        });
        return endpoints;
    }

}