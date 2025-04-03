using MapsterMapper;
using MediatR;
using WildNights.IdentityService.Api.Common.Error;
using WildNights.IdentityService.Api.Common.Interfaces;
using WildNights.IdentityService.Application.Authentication.Commands.Register;
using WildNights.IdentityService.Application.Authentication.Queries.Login;
using WildNights.IdentityService.Contracts.Authentication;
using WildNights.IdentityService.Domain.Common.Errors.Abstract;
using WildNights.IdentityService.Domain.Common.Errors.Models;

namespace WildNights.IdentityService.Api.Modules;

public class AuthenticationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {        
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("auth/register", async (RegisterRequest request, ISender _mediator, IMapper _mapper) =>
        {
            try
            {
                var registerCommand = _mapper.Map<RegisterCommand>(request);
                var registerResult = await _mediator.Send(registerCommand);
                var registerResponse = _mapper.Map<AuthenticationResponse>(registerResult);
                return Results.Ok(registerResponse);
            }
            catch (AuthenticationError err)
            {
                throw new ServiceError((int)err.HttpStatusCode, err.Message, ErrorType.AUTHENTICATION, err.Comment);
            }
            catch (ValidationError err) 
            {
                var errors = err.Flatten();
                if (errors.Count > 1)
                {
                    throw new AggregateError((int)err.HttpStatusCode, ErrorType.VALIDATION, errors);
                }
                throw new ServiceError((int)err.HttpStatusCode, err.Message, ErrorType.VALIDATION);
            }
        });

        endpoints.MapPost("auth/login", async (LoginRequest request, ISender _mediator, IMapper _mapper) =>
        {
            try
            {
                var loginQuery = _mapper.Map<LoginQuery>(request);
                var loginResult = await _mediator.Send(loginQuery);
                var loginResponse = _mapper.Map<AuthenticationResponse>(loginResult);
                return Results.Ok(loginResponse);
            }
            catch (AuthenticationError err)
            {
                throw new ServiceError((int)err.HttpStatusCode, err.Message, ErrorType.AUTHENTICATION, err.Comment);
            }
        });
        return endpoints;
    }

}