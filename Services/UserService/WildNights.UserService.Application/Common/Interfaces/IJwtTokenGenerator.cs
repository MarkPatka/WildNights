namespace WildNights.UserService.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateJwtToken(Guid userId, string firstName, string lastName);
}
