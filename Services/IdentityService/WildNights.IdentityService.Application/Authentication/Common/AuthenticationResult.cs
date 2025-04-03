using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
