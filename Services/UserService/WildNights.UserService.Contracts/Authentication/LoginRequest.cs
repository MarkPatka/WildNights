namespace WildNights.UserService.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password);
