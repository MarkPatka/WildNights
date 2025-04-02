using MediatR;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Application.Common.Interfaces.Authentication;
using WildNights.UserService.Application.Common.Interfaces.Persistence;
using WildNights.UserService.Domain.Common.Errors.Abstract;
using WildNights.UserService.Domain.Common.Errors.Models;
using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Authentication.Queries.Login;

public class LoginQueryHandler
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(
        LoginQuery query,
        CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new AuthenticationError(
                ErrorType.AUTHENTICATION.Description ?? "Invalid credentials", 
                System.Net.HttpStatusCode.Conflict,
                "SCR: Invalid email entered");
        }

        if (user.Password != query.Password)
        {
            throw new AuthenticationError(
                ErrorType.AUTHENTICATION.Description ?? "Invalid credentials",
                System.Net.HttpStatusCode.Conflict,
                "SCR: Invalid password entered");
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user);        
        return new AuthenticationResult(user, token);
    }
}
