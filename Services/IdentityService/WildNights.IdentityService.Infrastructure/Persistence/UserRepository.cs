using WildNights.IdentityService.Application.Common.Interfaces.Persistence;
using WildNights.IdentityService.Domain.Entites;

namespace WildNights.IdentityService.Infrastructure.Persistence;

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
