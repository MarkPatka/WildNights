using MediatR;
using WildNights.IdentityService.Application.Authentication.Common;

namespace WildNights.IdentityService.Application.Authentication.Queries.Login;


public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;