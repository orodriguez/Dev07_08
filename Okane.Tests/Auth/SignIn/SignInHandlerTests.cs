using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;

namespace Okane.Tests.Auth.SignIn;

public class SignInHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Valid()
    {
        Assert.IsType<UserResponse>(await HandleAsync(new SignUpRequest("user@mail.com", "4321")));

        var response = await HandleAsync(new SignInRequest("user@mail.com", "4321"));

        var token = Assert.IsType<TokenResponse>(response);
        
        Assert.Equal("FakeToken", token.Value);
    }
}