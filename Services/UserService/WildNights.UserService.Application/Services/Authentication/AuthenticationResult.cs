using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
