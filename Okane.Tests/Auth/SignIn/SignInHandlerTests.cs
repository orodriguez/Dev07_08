using FluentResults;
using Okane.Application.Auth;
using Okane.Application.Auth.SignIn;
using Okane.Application.Auth.Signup;
using Request = Okane.Application.Auth.Signup.Request;

namespace Okane.Tests.Auth.SignIn;

public class SignInHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Valid()
    {
        Assert.IsType<UserResponse>(await HandleAsync(new Request("user@mail.com", "4321")));

        var token = (await HandleAsync(new Application.Auth.SignIn.Request("user@mail.com", "4321"))).Value;
        
        Assert.Equal("FakeToken", token.Value);
    }
}