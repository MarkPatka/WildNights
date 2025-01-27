using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
