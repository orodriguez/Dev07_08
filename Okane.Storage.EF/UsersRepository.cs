using Okane.Application.Auth;
using Okane.Domain;

namespace Okane.Storage.EF;

public class UsersRepository : IUsersRepository
{
    private readonly OkaneDbContext _db;

    public UsersRepository(OkaneDbContext db) => _db = db;

    public User Add(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return user;
    }
}