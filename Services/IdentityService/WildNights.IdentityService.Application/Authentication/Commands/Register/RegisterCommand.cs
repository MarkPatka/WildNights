using MediatR;
using WildNights.IdentityService.Application.Authentication.Common;

namespace WildNights.IdentityService.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<AuthenticationResult>;
