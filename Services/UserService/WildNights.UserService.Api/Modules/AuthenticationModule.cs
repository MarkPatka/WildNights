using MediatR;
using WildNights.UserService.Api.Common.Error;
using WildNights.UserService.Api.Common.Interfaces;
using WildNights.UserService.Application.Authentication.Commands.Register;
using WildNights.UserService.Application.Authentication.Queries.Login;
using WildNights.UserService.Contracts.Authentication;
using WildNights.UserService.Domain.Common.Errors.Abstract;

namespace WildNights.UserService.Api.Modules;

public class AuthenticationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {        
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("auth/register", async (RegisterRequest request, IMediator _mediator) =>
        {
            try
            {
                var registerCommand = new RegisterCommand(
                    request.FirstName, 
                    request.LastName, 
                    request.Email, 
                    request.Password);
                
                var registerResult = await _mediator.Send(registerCommand);                

                var registerResponse = new AuthenticationResponse(
                    registerResult.User.Id,
                    registerResult.User.FirstName,
                    registerResult.User.LastName,
                    registerResult.User.Email,
                    registerResult.Token);

                return Results.Ok(registerResponse);
            }
            catch (Error err)
            {
                throw new ServiceError((int)err.StatusCode, err.ErrorMessage);
            }           
        });

        endpoints.MapPost("auth/login", async (LoginRequest request, IMediator _mediator) =>
        {
            try
            {
                var loginQuery = new LoginQuery(
                    request.Email, 
                    request.Password);

                var authenticationResult = await _mediator.Send(loginQuery);

                var loginResponse = new AuthenticationResponse(
                    authenticationResult.User.Id,
                    authenticationResult.User.FirstName,
                    authenticationResult.User.LastName,
                    authenticationResult.User.Email,
                    authenticationResult.Token);

                return Results.Ok(loginResponse);
            }
            catch (Error err)
            {
                throw new ServiceError((int)err.StatusCode, err.ErrorMessage);
            }
        });
        return endpoints;
    }

}