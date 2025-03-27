using MediatR;
using WildNights.UserService.Application.Authentication.Common;

namespace WildNights.UserService.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;
