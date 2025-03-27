using MediatR;
using WildNights.UserService.Application.Authentication.Common;

namespace WildNights.UserService.Application.Authentication.Queries.Login;


public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;