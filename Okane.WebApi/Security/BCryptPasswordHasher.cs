using Okane.Application.Auth.Signup;

namespace Okane.WebApi.Security;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password) => 
        BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string plainPassword, string hashedPassword) => 
        BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
}