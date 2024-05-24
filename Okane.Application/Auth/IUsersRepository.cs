using Okane.Domain;

namespace Okane.Application.Auth;

public interface IUsersRepository
{
    User Add(User user);
    
    // TODO: Make async
    User? ByEmail(string email);
}