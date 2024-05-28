using Okane.Application.Auth;

namespace Okane.Tests.Auth.SignIn;

public class SignInHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Valid()
    {
        App.Auth.SignUp("user@mail.com", "4123");
        App.Auth.SignIn("user@mail.com", "4321");

        var token = (await Handle(new Application.Auth.SignIn.Request("user@mail.com", "4321"))).Value;
        
        Assert.Equal("FakeToken", token.Value);
    }
}