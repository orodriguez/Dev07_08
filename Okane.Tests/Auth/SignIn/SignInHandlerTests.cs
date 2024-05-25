using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;

namespace Okane.Tests.Auth.SignIn;

public class SignInHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        Assert.IsType<UserResponse>(Handle(new SignUpRequest("user@mail.com", "4321")));

        var response = SignInUser(new SignInRequest("user@mail.com", "4321"));

        var token = Assert.IsType<TokenResponse>(response);
        
        Assert.Equal("FakeToken", token.Value);
    }
}