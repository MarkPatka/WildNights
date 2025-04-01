using MediatR;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Application.Common.Interfaces.Authentication;
using WildNights.UserService.Application.Common.Interfaces.Persistence;
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
            throw AuthenticationError.USER_NOT_EXIST;        

        if (user.Password != query.Password)
            throw AuthenticationError.INVALID_CREDENTIALS;

        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        
        return new AuthenticationResult(user, token);
    }
}
