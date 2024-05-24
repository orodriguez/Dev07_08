using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;

namespace Okane.Tests.Auth.SignIn;

public class SignInHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        Assert.IsType<UserResponse>(SignUpUser(new("user@mail.com", "4321")));

        var response = SignInUser(new SignInRequest("user@mail.com", "4321"));

        var token = Assert.IsType<TokenResponse>(response);
        
        Assert.Equal("FakeToken", token.Value);
    }
}