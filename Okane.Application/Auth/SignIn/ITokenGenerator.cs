using Okane.Domain;

namespace Okane.Application.Auth.SignIn;

public interface ITokenGenerator
{
    string Generate(User user);
}