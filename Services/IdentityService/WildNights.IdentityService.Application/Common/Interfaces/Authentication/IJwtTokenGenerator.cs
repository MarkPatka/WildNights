using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    public string GenerateJwtToken(User user);
}
