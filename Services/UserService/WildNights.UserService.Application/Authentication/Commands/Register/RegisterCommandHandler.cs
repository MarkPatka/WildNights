using MediatR;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Application.Common.Interfaces.Authentication;
using WildNights.UserService.Application.Common.Interfaces.Persistence;
using WildNights.UserService.Domain.Common.Errors.Models;
using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Authentication.Commands.Register;

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
            throw AuthenticationError.USER_EXISTS;

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
