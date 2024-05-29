using Okane.Domain;

namespace Okane.Application.Auth;

// TODO: Move this to separated project
public class InMemoryUsersRepository : IUsersRepository
{
    private int _nextId = 1;
    private readonly List<User> _users;

    public InMemoryUsersRepository() => _users = new List<User>();

    public User Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public User? ByEmail(string email) => 
        _users.Find(u => u.Email == email);
}