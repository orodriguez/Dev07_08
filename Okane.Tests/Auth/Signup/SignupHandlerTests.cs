using Okane.Application.Auth;
using Okane.Application.Auth.Signup;

namespace Okane.Tests.Auth.Signup;

public class SignupHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Valid()
    {
        PasswordHasherMock.Setup(hasher => hasher.Hash("1234")).Returns("H1234");
        
        var response = await Handle(new Request("user@mail.com", "1234"));

        var user = Assert.IsType<UserResponse>(response);
        
        Assert.Equal(1, user.Id);
        Assert.Equal("user@mail.com", user.Email);
    }
}