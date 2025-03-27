using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
