﻿using MediatR;
using WildNights.IdentityService.Application.Authentication.Common;
using WildNights.IdentityService.Application.Common.Interfaces.Authentication;
using WildNights.IdentityService.Application.Common.Interfaces.Persistence;
using WildNights.IdentityService.Domain.Common.Errors.Abstract;
using WildNights.IdentityService.Domain.Common.Errors.Models;
using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Application.Authentication.Commands.Register;

public class RegisterCommandHandler 
    : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    { 
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(
        RegisterCommand command, 
        CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new AuthenticationError(
                ErrorType.AUTHENTICATION.Description ?? "Invalid credentials",
                System.Net.HttpStatusCode.Conflict,
                "SCR: Attempt to register a user with an already registered email");
        }            

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        var token = _jwtTokenGenerator.GenerateJwtToken(user);        
        return new AuthenticationResult(user, token);
    }
}
