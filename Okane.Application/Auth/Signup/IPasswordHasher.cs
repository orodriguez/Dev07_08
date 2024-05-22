namespace Okane.Application.Auth.Signup;

public interface IPasswordHasher
{
    string Hash(string password);
}