using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    public string GenerateJwtToken(User user);
}
