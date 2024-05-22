using Okane.Domain;

namespace Okane.Application.Auth;

public interface IUsersRepository
{
    User Add(User user);
    User? ByEmail(string email);
}