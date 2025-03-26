using System.Net;
using WildNights.UserService.Application.Common.Errors;
using WildNights.UserService.Application.Common.Interfaces.Authentication;
using WildNights.UserService.Application.Common.Interfaces.Persistence;
using WildNights.UserService.Domain.Entites;
namespace WildNights.UserService.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;


    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid credentials");
        }

        if (user.Password != password) 
        {
            throw new Exception("Invalid credentials");
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(
        string firstName, string lastName, string email, string password)
    {

        if (_userRepository.GetUserByEmail(email) is not null)
            throw new DuplicateEmailError();

        var user = new User 
        {
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password 
        };
        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        return new AuthenticationResult(user, token);
    }
}
