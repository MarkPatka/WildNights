using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
