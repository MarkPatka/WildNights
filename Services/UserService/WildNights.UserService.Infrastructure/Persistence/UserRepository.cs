using WildNights.UserService.Application.Common.Interfaces.Persistence;
using WildNights.UserService.Domain.Entites;

namespace WildNights.UserService.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
